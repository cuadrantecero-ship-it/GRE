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

    public IDbConnection CreateConnection(string connectionName = "GestionRadioERP")
    {
        var connectionString =
            _configuration.GetConnectionString(connectionName)
            ?? throw new InvalidOperationException(
                $"No se encontró la cadena de conexión '{connectionName}'.");

        return new SqlConnection(connectionString);
    }
}