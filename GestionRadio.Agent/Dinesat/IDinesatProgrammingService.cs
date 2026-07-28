namespace GestionRadio.Agent.Dinesat;

public interface IDinesatProgrammingService
{
    Task<string> GetProgrammingStructureAsync();

    Task<string> GetProgrammingByDateAsync(
        string stationId,
        DateOnly fecha,
        int pgmTypeId);
}