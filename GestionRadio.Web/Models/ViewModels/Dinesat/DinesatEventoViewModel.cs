namespace GestionRadio.Web.Models.ViewModels.Dinesat;

/// <summary>
/// Evento (material) perteneciente a un bloque de programación.
/// </summary>
public sealed class DinesatEventoViewModel
{
    /// <summary>
    /// Identificador del evento.
    /// </summary>
    public long ProgramEventId { get; set; }

    /// <summary>
    /// Orden del material dentro del bloque.
    /// </summary>
    public int ItemOrder { get; set; }

    /// <summary>
    /// Identificador del material en Dinesat.
    /// </summary>
    public long MaterialId { get; set; }

    /// <summary>
    /// Código del material (COM00001, SPO00129, etc.).
    /// </summary>
    public string MaterialCode { get; set; } = string.Empty;

    /// <summary>
    /// Nombre del material.
    /// </summary>
    public string MaterialTitle { get; set; } = string.Empty;

    /// <summary>
    /// Duración del material en frames.
    /// </summary>
    public int LengthFrames { get; set; }

    /// <summary>
    /// Código de tráfico.
    /// </summary>
    public string? TrafficCode { get; set; }

    /// <summary>
    /// Índice de tráfico.
    /// </summary>
    public int TrafficIndex { get; set; }

    /// <summary>
    /// Descripción para eventos en vivo.
    /// </summary>
    public string? LiveDescription { get; set; }

    /// <summary>
    /// Duración del evento en vivo.
    /// </summary>
    public int LiveLength { get; set; }
}