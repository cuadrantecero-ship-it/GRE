using GestionRadio.Domain.Entities;

namespace GestionRadio.Domain.Interfaces;

/// <summary>
/// Acceso de solo lectura a los bloques de programación de Dinesat.
/// </summary>
public interface IDinesatProgramBlockRepository
{
    /// <summary>
    /// Obtiene todos los bloques de una programación.
    /// </summary>
    Task<IReadOnlyList<DinesatProgramBlock>> ObtenerPorProgramacionAsync(long programmingId);

    /// <summary>
    /// Obtiene un bloque por su identificador.
    /// </summary>
    Task<DinesatProgramBlock?> ObtenerPorIdAsync(long programBlockId);
}