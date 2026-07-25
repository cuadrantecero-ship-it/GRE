using GestionRadio.Domain.Entities;

namespace GestionRadio.Domain.Interfaces;

/// <summary>
/// Acceso de solo lectura a los eventos programados de Dinesat.
/// Corresponde a la tabla PROGRAMEVENT.
/// </summary>
public interface IDinesatProgramEventRepository
{
    /// <summary>
    /// Obtiene todos los eventos de un bloque.
    /// </summary>
    Task<IReadOnlyList<DinesatProgramEvent>> ObtenerPorBloqueAsync(long programBlockId);

    /// <summary>
    /// Obtiene un evento por su identificador.
    /// </summary>
    Task<DinesatProgramEvent?> ObtenerPorIdAsync(long programEventId);
}