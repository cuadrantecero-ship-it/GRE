using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services;

/// <summary>
/// Servicio de aplicación para consultar materiales de Dinesat.
/// </summary>
public sealed class DinesatMaterialService : IDinesatMaterialService
{
    private readonly IDinesatMaterialRepository _repository;

    public DinesatMaterialService(
        IDinesatMaterialRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Obtiene un material por su código.
    /// </summary>
    public async Task<DinesatMaterial?> ObtenerPorCodigoAsync(string codigo)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            return null;

        codigo = codigo.Trim().ToUpperInvariant();

        return await _repository.ObtenerPorCodigoAsync(codigo);
    }

    /// <summary>
    /// Obtiene todos los materiales activos.
    /// </summary>
    public async Task<IReadOnlyList<DinesatMaterial>> ObtenerActivosAsync()
    {
        return await _repository.ObtenerActivosAsync();
    }
}