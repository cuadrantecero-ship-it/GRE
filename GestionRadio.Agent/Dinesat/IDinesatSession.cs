namespace GestionRadio.Agent.Dinesat;

public interface IDinesatSession
{
    string? SessionId { get; }

    bool IsLoggedIn { get; }

    Task<bool> LoginAsync();

    Task LogoutAsync();
}