using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Dinesat;

public sealed class DinesatPublishService : IDinesatPublishService
{
    private readonly IDinesatProgrammingRepository _programmingRepository;
    private readonly IDinesatProgramBlockRepository _blockRepository;
    private readonly IDinesatProgramEventRepository _eventRepository;
    private readonly IDinesatMaterialRepository _materialRepository;
    private readonly IProgramacionDetalleRepository _detalleRepository;

    public DinesatPublishService(
        IDinesatProgrammingRepository programmingRepository,
        IDinesatProgramBlockRepository blockRepository,
        IDinesatProgramEventRepository eventRepository,
        IDinesatMaterialRepository materialRepository,
        IProgramacionDetalleRepository detalleRepository)
    {
        _programmingRepository = programmingRepository;
        _blockRepository = blockRepository;
        _eventRepository = eventRepository;
        _materialRepository = materialRepository;
        _detalleRepository = detalleRepository;
    }

    public async Task PublicarProgramacionAsync(long programacionId)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(programacionId);

        var detalles = (await _detalleRepository
            .ObtenerPorProgramacionAsync(programacionId))
            .ToList();

        if (detalles.Count == 0)
            return;

        foreach (var detalle in detalles)
        {
            await PublicarDetalleAsync(detalle);
        }
    }

    private async Task PublicarDetalleAsync(ProgramacionDetalle detalle)
    {
        ArgumentNullException.ThrowIfNull(detalle);

        // Si ya fue sincronizado con Dinesat, no hacer nada.
        if (detalle.Sincronizado)
            return;

        // =========================================================
        // PRÓXIMO PASO
        //
        // 1. Buscar PROGRAMBLOCK por la hora.
        // 2. Obtener MATERIALID.
        // 3. Insertar PROGRAMEVENT.
        // 4. Guardar los IDs de Dinesat.
        // 5. Marcar Sincronizado = true.
        // =========================================================

        await Task.CompletedTask;
    }
}