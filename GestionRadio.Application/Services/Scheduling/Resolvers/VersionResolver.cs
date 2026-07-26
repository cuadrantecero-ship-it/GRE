using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Scheduling.Resolvers;

/// <summary>
/// Resuelve una versión válida del ERP.
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
    /// Obtiene una versión válida.
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
}