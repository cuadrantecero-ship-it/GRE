namespace GestionRadio.Agent.Dinesat;

public interface IDinesatStationService
{
    Task<string> GetAllStationsAsync();
}