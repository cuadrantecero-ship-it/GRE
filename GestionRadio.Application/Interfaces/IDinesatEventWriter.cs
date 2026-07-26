namespace GestionRadio.Application.Interfaces;

/// <summary>
/// Escribe eventos de programación en Dinesat.
/// </summary>
public interface IDinesatEventWriter
{
    /// <summary>
    /// Inserta un evento en PROGRAMEVENT y devuelve el PGMEVENTID generado.
    /// </summary>
    Task<long> InsertarEventoAsync(
        long programBlockId,
        int itemOrder,
        long materialId,
        int condition,
        string? trafficCode = null,
        int? trafficIndex = null,
        string? liveDescription = null,
        int? liveLength = null);
}