using ServiceReference2;

namespace GestionRadio.Agent.Dinesat;

public class DinesatProgrammingService : IDinesatProgrammingService
{
    private readonly IDinesatSession _session;

    public DinesatProgrammingService(IDinesatSession session)
    {
        _session = session;
    }

    public async Task<string> GetProgrammingStructureAsync()
    {
        if (!_session.IsLoggedIn)
            throw new InvalidOperationException("No existe una sesión activa con Dinesat.");

        var client = new HdxStationsWebServiceClient();

        var request = new Programming_GetStructureRequest
        {
            SessionId = _session.SessionId!,
            ProgrammingStructureXML = ""
        };

        var response = await client.Programming_GetStructureAsync(request);

        if (!response.@return.StartsWith("0000"))
            throw new Exception(response.@return);

        return response.ProgrammingStructureXML;
    }

    public async Task<string> GetProgrammingByDateAsync(
        string stationId,
        DateOnly fecha,
        int pgmTypeId)
    {
        if (!_session.IsLoggedIn)
            throw new InvalidOperationException("No existe una sesión activa con Dinesat.");

        var client = new HdxStationsWebServiceClient();

        var request = new Programming_GetByDateRequest
        {
            SessionId = _session.SessionId!,
            StationID = stationId,
            PgmDate = fecha.ToString("yyyy/MM/dd"),
            PgmTypeId = pgmTypeId,
            UTCModifiedDate = "",
            UTCModifiedTime = "",
            ProgrammingXML = ""
        };

        var response = await client.Programming_GetByDateAsync(request);

        if (!response.@return.StartsWith("0000"))
            throw new Exception(response.@return);

        return response.ProgrammingXML;
    }
}