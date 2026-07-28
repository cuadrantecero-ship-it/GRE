using ServiceReference1;
using ServiceReference2;

namespace GestionRadio.Agent.Dinesat;

public static class DinesatStationTest
{
    public static async Task TestAsync()
    {
        // LOGIN
        var loginClient = new HdxSoapWebServiceClient();

        var login = await loginClient.Server_LogInAsync(
            new Server_LogInRequest
            {
                UserName = "Carlos",
                Password = "Radio5",
                HandledHdxMessagesXML = "",
                SessionId = ""
            });

        Console.WriteLine($"Login : {login.@return}");
        Console.WriteLine($"Session : {login.SessionId}");
        Console.WriteLine();

        // STATIONS
        var stationClient = new HdxStationsWebServiceClient();

        var response = await stationClient.Station_GetAllAsync(
            new Station_GetAllRequest
            {
                SessionId = login.SessionId,
                StationListXML = ""
            });

        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Return : {response.@return}");
        Console.WriteLine("--------------------------------");
        Console.WriteLine(response.StationListXML);
        Console.WriteLine("--------------------------------");
    }
}