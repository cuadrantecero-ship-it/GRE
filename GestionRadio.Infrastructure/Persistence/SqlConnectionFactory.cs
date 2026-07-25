using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace GestionRadio.Infrastructure.Persistence;

public sealed class SqlConnectionFactory
{
    private readonly IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Conexión al ERP.
    /// </summary>
    public IDbConnection CreateGestionRadioConnection()
    {
        var connectionString =
            _configuration.GetConnectionString("GestionRadioERP")
            ?? throw new InvalidOperationException(
                "No se encontró la cadena de conexión 'GestionRadioERP'.");

        return new SqlConnection(connectionString);
    }

    /// <summary>
    /// Conexión a Dinesat.
    /// </summary>
    public IDbConnection CreateDinesatConnection()
    {
        var connectionString =
            _configuration.GetConnectionString("DinesatRadio9")
            ?? throw new InvalidOperationException(
                "No se encontró la cadena de conexión 'DinesatRadio9'.");

        return new SqlConnection(connectionString);
    }

    /// <summary>
    /// Método genérico para compatibilidad con el resto del proyecto.
    /// </summary>
    public IDbConnection CreateConnection(string connectionName = "GestionRadioERP")
    {
        var connectionString =
            _configuration.GetConnectionString(connectionName)
            ?? throw new InvalidOperationException(
                $"No se encontró la cadena de conexión '{connectionName}'.");

        return new SqlConnection(connectionString);
    }
}