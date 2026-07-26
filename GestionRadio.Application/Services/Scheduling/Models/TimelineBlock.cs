namespace GestionRadio.Application.Services.Scheduling.Models;

public sealed class TimelineBlock
{
    public TimeOnly Hora { get; set; }

    public string Descripcion { get; set; } = string.Empty;

    public bool PermitePublicidad { get; set; }

    public int DuracionMaximaSegundos { get; set; }

    public List<ScheduledEvent> Events { get; set; } = new();
}