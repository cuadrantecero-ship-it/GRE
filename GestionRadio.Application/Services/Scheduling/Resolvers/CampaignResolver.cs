using GestionRadio.Application.Services.Scheduling.Models;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Scheduling.Resolvers;

/// <summary>
/// Obtiene únicamente las campañas elegibles que ya cuentan
/// con al menos una versión activa.
/// </summary>
public sealed class CampaignResolver
{
    private readonly ICampaniaRepository _campaniaRepository;
    private readonly IVersionRepository _versionRepository;

    public CampaignResolver(
        ICampaniaRepository campaniaRepository,
        IVersionRepository versionRepository)
    {
        _campaniaRepository = campaniaRepository
            ?? throw new ArgumentNullException(nameof(campaniaRepository));

        _versionRepository = versionRepository
            ?? throw new ArgumentNullException(nameof(versionRepository));
    }

    /// <summary>
    /// Devuelve únicamente las campañas listas para programarse.
    /// </summary>
    public async Task<IReadOnlyList<CampaignCandidate>> ResolveAsync(
        DateOnly fecha)
    {
        var campanias =
            await _campaniaRepository.ObtenerCampaniasElegiblesAsync(fecha);

        var resultado = new List<CampaignCandidate>();

        foreach (var campania in campanias
                     .Where(c => c.Activo)
                     .OrderByDescending(c => c.Prioridad)
                     .ThenBy(c => c.Nombre))
        {
            var versiones =
                await _versionRepository.ObtenerPorCampaniaAsync(
                    campania.IdCampania);

            if (!versiones.Any(v => v.Activo))
            {
                // La campaña aún no está lista para salir al aire.
                continue;
            }

            resultado.Add(new CampaignCandidate
            {
                ClienteId = campania.IdCliente,
                CampaniaId = campania.IdCampania,
                NombreCampania = campania.Nombre,
                FechaInicio = campania.FechaInicio,
                FechaFin = campania.FechaFin,
                Prioridad = campania.Prioridad,
                Activa = campania.Activo
            });
        }

        return resultado;
    }
}