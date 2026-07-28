namespace GestionRadio.Agent.Models;

public class ProgrammingBlock
{
    public int PgmBlockId { get; set; }

    public string Description { get; set; } = string.Empty;

    public TimeSpan BlockTime { get; set; }

    public List<ProgrammingEvent> Events { get; set; } = new();
}