using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Scheduling.Resolvers;

/// <summary>
/// Resuelve la versión que debe utilizar el motor de programación.
/// </summary>
public sealed class VersionResolver
{
    private readonly IVersionRepository _versionRepository;

    public VersionResolver(IVersionRepository versionRepository)
    {
        _versionRepository = versionRepository
            ?? throw new ArgumentNullException(nameof(versionRepository));
    }

    /// <summary>
    /// Obtiene una versión específica por Id.
    /// </summary>
    public async Task<VersionCampania> ObtenerAsync(long idVersion)
    {
        var version = await _versionRepository.ObtenerPorIdAsync(idVersion);

        if (version is null)
        {
            throw new InvalidOperationException(
                $"No existe la versión {idVersion}.");
        }

        if (!version.Activo)
        {
            throw new InvalidOperationException(
                $"La versión {idVersion} se encuentra desactivada.");
        }

        return version;
    }

    /// <summary>
    /// Resuelve automáticamente la versión que debe reproducirse
    /// para una campaña.
    /// </summary>
    public async Task<VersionCampania> ResolverParaCampaniaAsync(long idCampania)
    {
        var versiones = (await _versionRepository
                .ObtenerPorCampaniaAsync(idCampania))
            .Where(v => v.Activo)
            .OrderBy(v => v.IdVersion)
            .ToList();

        if (versiones.Count == 0)
        {
            throw new InvalidOperationException(
                $"La campaña {idCampania} no tiene versiones activas.");
        }

        // Primera implementación:
        // devolver la primera versión activa.
        //
        // Más adelante aquí implementaremos:
        // - Rotación
        // - Peso
        // - Frecuencia
        // - Evitar repetición
        // - Balanceo automático

        return versiones.First();
    }
}