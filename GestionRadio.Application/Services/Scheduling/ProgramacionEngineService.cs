using GestionRadio.Application.DTOs.Programacion;
using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Scheduling;

/// <summary>
/// Motor de Programación.
/// Coordina la programación entre GESTIÓN RADIO y Dinesat.
/// </summary>
public sealed class ProgramacionEngineService : IProgramacionEngineService
{
    private readonly IVersionRepository _versionRepository;
    private readonly IDinesatMaterialRepository _materialRepository;
    private readonly IDinesatProgramBlockRepository _programBlockRepository;
    private readonly IDinesatProgramEventRepository _programEventRepository;
    private readonly IProgramacionRepository _programacionRepository;

    public ProgramacionEngineService(
        IVersionRepository versionRepository,
        IDinesatMaterialRepository materialRepository,
        IDinesatProgramBlockRepository programBlockRepository,
        IDinesatProgramEventRepository programEventRepository,
        IProgramacionRepository programacionRepository)
    {
        _versionRepository = versionRepository;
        _materialRepository = materialRepository;
        _programBlockRepository = programBlockRepository;
        _programEventRepository = programEventRepository;
        _programacionRepository = programacionRepository;
    }

    /// <summary>
    /// Programa una versión en Dinesat y registra la operación en el ERP.
    /// </summary>
    public async Task<ProgramacionDto> ProgramarAsync(ProgramacionCreateDto request)
    {
        // TODO:
        // 1. Obtener la versión.
        // 2. Obtener el material de Dinesat.
        // 3. Localizar el bloque.
        // 4. Calcular ItemOrder.
        // 5. Insertar PROGRAMEVENT.
        // 6. Guardar GR_PROGRAMACION.

        throw new NotImplementedException();
    }
}