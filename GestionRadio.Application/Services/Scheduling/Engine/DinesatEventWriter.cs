using GestionRadio.Application.Interfaces;

namespace GestionRadio.Application.Scheduling.Engine;

/// <summary>
/// Implementa la escritura de eventos en la tabla PROGRAMEVENT de Dinesat.
/// La lógica de inserción se implementará en el siguiente paso.
/// </summary>
public sealed class DinesatEventWriter : IDinesatEventWriter
{
    public Task<long> InsertarEventoAsync(
        long programBlockId,
        int itemOrder,
        long materialId,
        int condition,
        string? trafficCode = null,
        int? trafficIndex = null,
        string? liveDescription = null,
        int? liveLength = null)
    {
        throw new NotImplementedException();
    }
}