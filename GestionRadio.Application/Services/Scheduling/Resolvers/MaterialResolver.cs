using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Scheduling.Resolvers;

/// <summary>
/// Resuelve un material existente en Dinesat.
/// </summary>
public sealed class MaterialResolver
{
    private readonly IDinesatMaterialRepository _materialRepository;

    public MaterialResolver(IDinesatMaterialRepository materialRepository)
    {
        _materialRepository = materialRepository
            ?? throw new ArgumentNullException(nameof(materialRepository));
    }

    /// <summary>
    /// Obtiene un material válido por su código.
    /// </summary>
    public async Task<DinesatMaterial> ObtenerAsync(string codigo)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("Debe indicar un código de material.", nameof(codigo));

        var material = await _materialRepository.ObtenerPorCodigoAsync(codigo);

        if (material is null)
        {
            throw new InvalidOperationException(
                $"No existe el material '{codigo}' en Dinesat.");
        }

        return material;
    }
}