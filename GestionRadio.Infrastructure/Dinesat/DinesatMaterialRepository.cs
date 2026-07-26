using Dapper;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;

namespace GestionRadio.Infrastructure.Dinesat;

public sealed class DinesatSyncRepository : IDinesatSyncRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public DinesatSyncRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task SincronizarAsync()
    {
        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        using var tx = cn.BeginTransaction();

        try
        {
            // Aquí construiremos el motor de sincronización.

            tx.Commit();
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }
}