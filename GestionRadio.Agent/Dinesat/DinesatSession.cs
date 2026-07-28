using GestionRadio.Agent.Configuration;
using Microsoft.Extensions.Options;
using ServiceReference1;

namespace GestionRadio.Agent.Dinesat;

public class DinesatSession : IDinesatSession
{
    private readonly DinesatOptions _options;

    public string? SessionId { get; private set; }

    public bool IsLoggedIn => !string.IsNullOrWhiteSpace(SessionId);

    public DinesatSession(IOptions<DinesatOptions> options)
    {
        _options = options.Value;
    }

    public async Task<bool> LoginAsync()
    {
        var client = new HdxSoapWebServiceClient();

        var response = await client.Server_LogInAsync(
            new Server_LogInRequest
            {
                UserName = _options.UserName,
                Password = _options.Password,
                HandledHdxMessagesXML = "",
                SessionId = ""
            });

        if (!response.@return.StartsWith("0000"))
            return false;

        SessionId = response.SessionId;

        return true;
    }

    public async Task LogoutAsync()
    {
        if (!IsLoggedIn)
            return;

        var client = new HdxSoapWebServiceClient();

        await client.Server_LogOutAsync(SessionId!);

        SessionId = null;
    }
}