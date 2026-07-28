using GestionRadio.Application.DTOs.Programacion;

namespace GestionRadio.Application.Interfaces;

/// <summary>
/// Motor de sincronización entre GESTIÓN RADIO y Dinesat.
/// </summary>
public interface IProgramacionEngineService
{
    Task<ProgramacionDto> ProgramarAsync(long programacionId);
}