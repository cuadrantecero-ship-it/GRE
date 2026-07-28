using ServiceReference2;

namespace GestionRadio.Agent.Dinesat;

public class DinesatStationService : IDinesatStationService
{
    private readonly IDinesatSession _session;

    public DinesatStationService(IDinesatSession session)
    {
        _session = session;
    }

    public async Task<string> GetAllStationsAsync()
    {
        if (!_session.IsLoggedIn)
            throw new InvalidOperationException("No existe una sesión activa con Dinesat.");

        var client = new HdxStationsWebServiceClient();

        var response = await client.Station_GetAllAsync(
            new Station_GetAllRequest
            {
                SessionId = _session.SessionId!,
                StationListXML = ""
            });

        if (!response.@return.StartsWith("0000"))
            throw new Exception(response.@return);

        return response.StationListXML;
    }
}