namespace GestionRadio.Application.Services.Scheduling.Models;

public sealed class ScheduledEvent
{
    public int Orden { get; set; }

    public long MaterialId { get; set; }

    public string Codigo { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public int DuracionSegundos { get; set; }
}