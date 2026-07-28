using ServiceReference1;

namespace GestionRadio.Agent.Dinesat;

public static class DinesatLoginTest
{
    public static async Task TestAsync()
    {
        try
        {
            Console.WriteLine("Conectando a Dinesat...");

            var client = new HdxSoapWebServiceClient();

            var request = new Server_LogInRequest
            {
                UserName = "Carlos",          // <-- tu usuario
                Password = "Radio5",     // <-- tu contraseña
                HandledHdxMessagesXML = "",
                SessionId = ""
            };

            var response = await client.Server_LogInAsync(request);

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Return    : {response.@return}");
            Console.WriteLine($"SessionId : {response.SessionId}");
            Console.WriteLine("--------------------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR");
            Console.WriteLine(ex.ToString());
        }
    }
}