namespace GestionRadio.Agent.Models;

public class ProgrammingEvent
{
    public int PgmEventId { get; set; }

    public int ItemId { get; set; }

    public int MaterialId { get; set; }

    public int Condition { get; set; }

    public string TrafficCode { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public int Length { get; set; }

    public int PriorityId { get; set; }

    public string ArtistName { get; set; } = string.Empty;
}