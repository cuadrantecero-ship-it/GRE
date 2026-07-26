using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Scheduling.Resolvers;

/// <summary>
/// Obtiene una versión válida desde el ERP.
/// </summary>
public sealed class VersionResolver
{
    private readonly IVersionRepository _versionRepository;

    public VersionResolver(IVersionRepository versionRepository)
    {
        _versionRepository = versionRepository;
    }

    public async Task<VersionCampania> ObtenerAsync(long idVersion)
    {
        var version = await _versionRepository.ObtenerPorIdAsync(idVersion);

        if (version is null)
            throw new InvalidOperationException(
                $"No existe la versión {idVersion}.");

        if (!version.Activo)
            throw new InvalidOperationException(
                "La versión se encuentra desactivada.");

        return version;
    }
}