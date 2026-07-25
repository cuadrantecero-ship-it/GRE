using GestionRadio.Domain.Entities;

namespace GestionRadio.Domain.Interfaces;

/// <summary>
/// Acceso de solo lectura a los materiales almacenados en Dinesat.
/// </summary>
public interface IDinesatMaterialRepository
{
    /// <summary>
    /// Obtiene un material por su código (ejemplo: SPO00004).
    /// </summary>
    Task<DinesatMaterial?> ObtenerPorCodigoAsync(string codigo);

    /// <summary>
    /// Obtiene todos los materiales activos.
    /// </summary>
    Task<IReadOnlyList<DinesatMaterial>> ObtenerActivosAsync();
}