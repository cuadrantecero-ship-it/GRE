namespace GestionRadio.Application.Models;

/// <summary>
/// Solicitud enviada al Motor Inteligente de Rotación.
/// Contiene toda la información necesaria para seleccionar
/// la mejor versión de una campaña.
/// </summary>
public sealed class RotationRequest
{
    /// <summary>
    /// Campaña que se desea programar.
    /// </summary>
    public long CampaignId { get; set; }

    /// <summary>
    /// Emisora donde se programará.
    /// </summary>
    public long StationId { get; set; }

    /// <summary>
    /// Fecha de transmisión.
    /// </summary>
    public DateTime Fecha { get; set; }

    /// <summary>
    /// Hora del bloque.
    /// </summary>
    public TimeSpan Hora { get; set; }

    /// <summary>
    /// Bloque de Dinesat donde se insertará.
    /// </summary>
    public long ProgramBlockId { get; set; }

    /// <summary>
    /// Usuario que realiza la operación.
    /// </summary>
    public string Usuario { get; set; } = string.Empty;
}