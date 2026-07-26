using GestionRadio.Application.DTOs.Programacion;

namespace GestionRadio.Application.Interfaces;

/// <summary>
/// Contrato del Motor de Programación.
/// </summary>
public interface IProgramacionEngineService
{
    Task<ProgramacionDto> ProgramarAsync(ProgramacionCreateDto request);
}