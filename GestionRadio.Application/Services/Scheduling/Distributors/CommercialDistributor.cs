using GestionRadio.Application.Services.Scheduling.Models;

namespace GestionRadio.Application.Services.Scheduling.Distributors;

/// <summary>
/// Distribuye la cola comercial dentro del Timeline.
/// Primera versión:
/// Asigna una campaña por bloque.
/// </summary>
public sealed class CommercialDistributor
{
    public IReadOnlyDictionary<TimelineBlock, List<CommercialQueueItem>> Distribute(
        SchedulingDay schedulingDay,
        IReadOnlyList<CommercialQueueItem> queue)
    {
        ArgumentNullException.ThrowIfNull(schedulingDay);
        ArgumentNullException.ThrowIfNull(queue);

        var result = new Dictionary<TimelineBlock, List<CommercialQueueItem>>();

        var queueIndex = 0;

        foreach (var block in schedulingDay.Blocks)
        {
            if (!block.PermitePublicidad)
                continue;

            result[block] = new List<CommercialQueueItem>();

            if (queueIndex >= queue.Count)
                continue;

            var item = queue[queueIndex];

            if (!item.Terminada)
            {
                result[block].Add(item);

                item.Utilizadas++;

                queueIndex++;
            }
        }

        return result;
    }
}