using GestionRadio.Application.DTOs.Programacion;
using GestionRadio.Application.Interfaces;
using GestionRadio.Application.Scheduling.Engine;
using GestionRadio.Application.Services.Scheduling.Builders;
using GestionRadio.Application.Services.Scheduling.Resolvers;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Scheduling;

/// <summary>
/// Motor de Programación.
/// Coordina la programación entre GESTIÓN RADIO y Dinesat.
/// </summary>
public sealed class ProgramacionEngineService : IProgramacionEngineService
{
    private readonly VersionResolver _versionResolver;
    private readonly MaterialResolver _materialResolver;
    private readonly BlockResolver _blockResolver;
    private readonly ProgrammingResolver _programmingResolver;
    private readonly ItemOrderCalculator _itemOrderCalculator;
    private readonly ProgramEventBuilder _programEventBuilder;

    private readonly IDinesatProgramEventRepository _programEventRepository;
    private readonly IProgramacionRepository _programacionRepository;


    public ProgramacionEngineService(
        VersionResolver versionResolver,
        MaterialResolver materialResolver,
        BlockResolver blockResolver,
        ProgrammingResolver programmingResolver,
        ItemOrderCalculator itemOrderCalculator,
        ProgramEventBuilder programEventBuilder,
        IDinesatProgramEventRepository programEventRepository,
        IProgramacionRepository programacionRepository)
    {
        _versionResolver = versionResolver
            ?? throw new ArgumentNullException(nameof(versionResolver));

        _materialResolver = materialResolver
            ?? throw new ArgumentNullException(nameof(materialResolver));

        _blockResolver = blockResolver
            ?? throw new ArgumentNullException(nameof(blockResolver));

        _programmingResolver = programmingResolver
            ?? throw new ArgumentNullException(nameof(programmingResolver));

        _itemOrderCalculator = itemOrderCalculator
            ?? throw new ArgumentNullException(nameof(itemOrderCalculator));

        _programEventBuilder = programEventBuilder
            ?? throw new ArgumentNullException(nameof(programEventBuilder));

        _programEventRepository = programEventRepository
            ?? throw new ArgumentNullException(nameof(programEventRepository));

        _programacionRepository = programacionRepository
            ?? throw new ArgumentNullException(nameof(programacionRepository));
    }


    /// <summary>
    /// Programa una versión en Dinesat y registra la operación en el ERP.
    /// </summary>
    public async Task<ProgramacionDto> ProgramarAsync(
        ProgramacionCreateDto request)
    {
        ArgumentNullException.ThrowIfNull(request);


        // 1. Obtener versión ERP.
        var version =
            await _versionResolver.ObtenerAsync(request.IdVersion);


        // 2. Obtener material desde Dinesat.
        var material =
            await _materialResolver.ObtenerAsync(version.CodigoMaterial);


        // 3. Obtener programación Dinesat.
        var programming =
            await _programmingResolver.ObtenerAsync(request);


        // 4. Obtener bloque horario.
        var block =
            await _blockResolver.ObtenerAsync(
                programming.ProgrammingId,
                request.HoraProgramada);


        // 5. Calcular ITEMORDER.
        var itemOrder =
            await _itemOrderCalculator.ObtenerSiguienteAsync(
                block.ProgramBlockId);


        // 6. Crear evento Dinesat.
        var evento =
            _programEventBuilder.ConstruirSpot(
                block.ProgramBlockId,
                itemOrder,
                material.MaterialIdDinesat,
                "COM");


        // Completar información del material.
        evento.MaterialCode = material.Codigo;
        evento.MaterialTitle = material.Titulo;


        // 7. Insertar PROGRAMEVENT.
        var programEventId =
            await _programEventRepository.InsertarAsync(evento);


        // 8. Crear registro ERP.
        var programacion = new Programacion
        {
            IdCampania = request.IdCampania,
            IdVersion = request.IdVersion,
            IdEmisora = request.IdEmisora,

            FechaProgramacion = request.FechaProgramacion,
            HoraProgramada = request.HoraProgramada,

            ProgrammingIdDinesat = programming.ProgrammingId,
            ProgramBlockIdDinesat = block.ProgramBlockId,
            ProgramEventIdDinesat = programEventId,

            MaterialIdDinesat = material.MaterialIdDinesat,
            CodigoMaterial = material.Codigo,
            TituloMaterial = material.Titulo,
            DuracionSegundos = request.DuracionSegundos,

            Orden = itemOrder,

            Transmitido = false,
            Activo = true,

            FechaAlta = DateTime.Now,
            UsuarioAlta = "ADMIN"
        };


        // 9. Guardar GR_PROGRAMACION.
        var idProgramacion =
            await _programacionRepository.InsertarAsync(programacion);


        // 10. Respuesta.
        return new ProgramacionDto
        {
            IdProgramacion = idProgramacion,

            IdCampania = programacion.IdCampania,
            IdVersion = programacion.IdVersion,
            IdEmisora = programacion.IdEmisora,

            FechaProgramacion = programacion.FechaProgramacion,
            HoraProgramada = programacion.HoraProgramada,

            MaterialIdDinesat = programacion.MaterialIdDinesat,

            ProgrammingIdDinesat = programacion.ProgrammingIdDinesat,
            ProgramBlockIdDinesat = programacion.ProgramBlockIdDinesat,
            ProgramEventIdDinesat = programacion.ProgramEventIdDinesat,

            CodigoMaterial = programacion.CodigoMaterial,
            TituloMaterial = programacion.TituloMaterial,

            DuracionSegundos = programacion.DuracionSegundos,

            Orden = programacion.Orden,

            Transmitido = programacion.Transmitido,
            Activo = programacion.Activo
        };
    }
}