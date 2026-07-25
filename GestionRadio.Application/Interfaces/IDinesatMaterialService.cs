using GestionRadio.Domain.Entities;

namespace GestionRadio.Application.Interfaces;

/// <summary>
/// Servicio de aplicación para consultar materiales en Dinesat.
/// </summary>
public interface IDinesatMaterialService
{
    /// <summary>
    /// Obtiene un material por su código.
    /// </summary>
    Task<DinesatMaterial?> ObtenerPorCodigoAsync(string codigo);

    /// <summary>
    /// Obtiene todos los materiales activos.
    /// </summary>
    Task<IReadOnlyList<DinesatMaterial>> ObtenerActivosAsync();
}