namespace GestionRadio.Application.Services.Scheduling.Models;

/// <summary>
/// Representa un evento disponible dentro del timeline de programación.
/// Es generado a partir de la parrilla y posteriormente utilizado por el
/// Scheduler para asignar campañas y construir ProgramacionDetalle.
/// </summary>
public sealed class TimelineBlock
{
    //==========================================================
    // IDENTIFICACIÓN
    //==========================================================

    /// <summary>
    /// Id del evento de la parrilla.
    /// </summary>
    public long EventoId { get; set; }

    //==========================================================
    // PROGRAMACIÓN
    //==========================================================

    public TimeOnly Hora { get; set; }

    public string Descripcion { get; set; } = string.Empty;

    public bool PermitePublicidad { get; set; }

    public int DuracionMaximaSegundos { get; set; }

    //==========================================================
    // EVENTOS PROGRAMADOS
    //==========================================================

    public List<ScheduledEvent> Events { get; set; } = new();
}