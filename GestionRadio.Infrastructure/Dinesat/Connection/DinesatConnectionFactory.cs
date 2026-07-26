using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace GestionRadio.Infrastructure.Dinesat.Connection;

public sealed class DinesatConnectionFactory
{
    private readonly string _connectionString;

    public DinesatConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Dinesat")
            ?? throw new InvalidOperationException(
                "No se encontró la cadena de conexión 'Dinesat'.");
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}