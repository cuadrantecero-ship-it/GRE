namespace GestionRadio.Domain.Entities;

/// <summary>
/// Representa un evento (material) programado dentro de un bloque de Dinesat.
/// Corresponde a la tabla PROGRAMEVENT.
/// </summary>
public sealed class DinesatProgramEvent
{
    /// <summary>
    /// Identificador del evento.
    /// </summary>
    public long ProgramEventId { get; set; }

    /// <summary>
    /// Bloque al que pertenece.
    /// </summary>
    public long ProgramBlockId { get; set; }

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
    /// Título o nombre del material.
    /// </summary>
    public string MaterialTitle { get; set; } = string.Empty;

    /// <summary>
    /// Duración del material en frames.
    /// Calculada como ENDPOS - STARTPOS.
    /// </summary>
    public int LengthFrames { get; set; }

    /// <summary>
    /// Condición utilizada por Dinesat.
    /// </summary>
    public int Condition { get; set; }

    /// <summary>
    /// Código de tráfico (RTC, COM, etc.).
    /// </summary>
    public string? TrafficCode { get; set; }

    /// <summary>
    /// Índice de tráfico.
    /// </summary>
    public int TrafficIndex { get; set; }

    /// <summary>
    /// Texto para eventos en vivo.
    /// </summary>
    public string? LiveDescription { get; set; }

    /// <summary>
    /// Duración del evento en vivo.
    /// </summary>
    public int LiveLength { get; set; }
}