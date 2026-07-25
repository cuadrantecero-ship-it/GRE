using GestionRadio.Domain.Entities;

namespace GestionRadio.Application.Interfaces;

/// <summary>
/// Servicio de aplicación para consultar los eventos programados de Dinesat.
/// </summary>
public interface IDinesatProgramEventService
{
    /// <summary>
    /// Obtiene todos los eventos de un bloque de programación.
    /// </summary>
    Task<IReadOnlyList<DinesatProgramEvent>> ObtenerPorBloqueAsync(long programBlockId);

    /// <summary>
    /// Obtiene un evento específico.
    /// </summary>
    Task<DinesatProgramEvent?> ObtenerPorIdAsync(long programEventId);
}