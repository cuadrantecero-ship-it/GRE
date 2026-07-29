using GestionRadio.Application.Services.Scheduling.Models;

namespace GestionRadio.Application.Services.Scheduling.Builders;

/// <summary>
/// Construye la cola comercial utilizada por el Scheduler.
/// </summary>
public sealed class CommercialQueueBuilder
{
    public IReadOnlyList<CommercialQueueItem> Build(
        IReadOnlyList<CampaignCandidate> campaigns)
    {
        ArgumentNullException.ThrowIfNull(campaigns);

        var queue = campaigns
            .Select(c => new CommercialQueueItem
            {
                Campaign = c,

                // Primera implementación:
                // Una inserción por campaña.
                Pendientes = 1,

                Utilizadas = 0
            })
            .ToList();

        return queue;
    }
}