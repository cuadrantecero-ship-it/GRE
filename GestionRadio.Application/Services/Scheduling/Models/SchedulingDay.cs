namespace GestionRadio.Application.Services.Scheduling.Models;

public sealed class SchedulingDay
{
    public DateOnly Fecha { get; set; }

    public long EmisoraId { get; set; }

    public List<TimelineBlock> Blocks { get; set; } = new();
}