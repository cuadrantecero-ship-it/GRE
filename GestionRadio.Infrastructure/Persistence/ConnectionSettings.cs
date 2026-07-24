namespace GestionRadio.Infrastructure.Persistence;

/// <summary>
/// Configuración de conexión a SQL Server.
/// Esta clase se enlaza con la sección "ConnectionSettings"
/// del archivo appsettings.json.
/// </summary>
public class ConnectionSettings
{
    /// <summary>
    /// Cadena de conexión principal.
    /// </summary>
    public string DefaultConnection { get; set; } = string.Empty;

    /// <summary>
    /// Tiempo de espera (segundos).
    /// </summary>
    public int CommandTimeout { get; set; } = 30;
}