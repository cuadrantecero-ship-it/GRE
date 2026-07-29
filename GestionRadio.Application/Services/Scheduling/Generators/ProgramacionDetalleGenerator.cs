using GestionRadio.Application.Services.Scheduling.Builders;
using GestionRadio.Application.Services.Scheduling.Distributors;
using GestionRadio.Application.Services.Scheduling.Factories;
using GestionRadio.Application.Services.Scheduling.Resolvers;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Scheduling.Generators;

public sealed class ProgramacionDetalleGenerator
{
    private readonly TimelineBuilder _timelineBuilder;
    private readonly CampaignResolver _campaignResolver;
    private readonly CommercialQueueBuilder _queueBuilder;
    private readonly CommercialDistributor _distributor;
    private readonly VersionResolver _versionResolver;
    private readonly ProgramacionDetalleFactory _factory;
    private readonly IProgramacionDetalleRepository _detalleRepository;

    public ProgramacionDetalleGenerator(
        TimelineBuilder timelineBuilder,
        CampaignResolver campaignResolver,
        CommercialQueueBuilder queueBuilder,
        CommercialDistributor distributor,
        VersionResolver versionResolver,
        ProgramacionDetalleFactory factory,
        IProgramacionDetalleRepository detalleRepository)
    {
        _timelineBuilder = timelineBuilder
            ?? throw new ArgumentNullException(nameof(timelineBuilder));

        _campaignResolver = campaignResolver
            ?? throw new ArgumentNullException(nameof(campaignResolver));

        _queueBuilder = queueBuilder
            ?? throw new ArgumentNullException(nameof(queueBuilder));

        _distributor = distributor
            ?? throw new ArgumentNullException(nameof(distributor));

        _versionResolver = versionResolver
            ?? throw new ArgumentNullException(nameof(versionResolver));

        _factory = factory
            ?? throw new ArgumentNullException(nameof(factory));

        _detalleRepository = detalleRepository
            ?? throw new ArgumentNullException(nameof(detalleRepository));
    }

    public async Task GenerarAsync(Programacion programacion)
    {
        ArgumentNullException.ThrowIfNull(programacion);

        //==================================================
        // 1. Construir Timeline
        //==================================================

        var schedulingDay = await _timelineBuilder.BuildAsync(
            programacion.Fecha,
            programacion.EmisoraId);

        //==================================================
        // 2. Obtener campañas elegibles
        //==================================================

        var campaigns = await _campaignResolver.ResolveAsync(
            programacion.Fecha);

        //==================================================
        // 3. Construir cola comercial
        //==================================================

        var queue = _queueBuilder.Build(campaigns);

        //==================================================
        // 4. Distribuir campañas
        //==================================================

        var distribution = _distributor.Distribute(
            schedulingDay,
            queue);

        //==================================================
        // 5. Generar ProgramacionDetalle
        //==================================================

        foreach (var blockDistribution in distribution)
        {
            var block = blockDistribution.Key;

            var orden = 1;

            foreach (var queueItem in blockDistribution.Value)
            {
                var version =
                    await _versionResolver.ResolverParaCampaniaAsync(
                        queueItem.CampaniaId);

                var detalle = _factory.Crear(
                    programacion,
                    block,
                    queueItem.Campaign,
                    version,
                    orden);

                await _detalleRepository.InsertarAsync(detalle);

                orden++;
            }
        }
    }
}