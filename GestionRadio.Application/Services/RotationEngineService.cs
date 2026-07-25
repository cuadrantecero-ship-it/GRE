using GestionRadio.Application.Interfaces;
using GestionRadio.Application.Models;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services;

/// <summary>
/// Motor Inteligente de Rotación.
/// Primera versión funcional.
/// </summary>
public sealed class RotationEngineService : IRotationEngineService
{
    private readonly IVersionRepository _versionRepository;

    public RotationEngineService(
        IVersionRepository versionRepository)
    {
        _versionRepository = versionRepository;
    }

    public async Task<RotationResult> SeleccionarVersionAsync(RotationRequest request)
    {
        var versiones =
            (await _versionRepository.ObtenerPorCampaniaAsync(request.CampaignId))
            .ToList();

        if (!versiones.Any())
        {
            return new RotationResult
            {
                Success = false,
                Message = "La campaña no tiene versiones activas.",
                RuleApplied = "ACTIVE_VERSION_RULE"
            };
        }

        var version = versiones.First();

        return new RotationResult
        {
            Success = true,
            VersionId = version.IdVersion,
            MaterialCode = version.CodigoMaterial,
            VersionName = version.TituloMaterial,
            RuleApplied = "FIRST_ACTIVE_VERSION",
            Message = "Versión seleccionada correctamente."
        };
    }
}