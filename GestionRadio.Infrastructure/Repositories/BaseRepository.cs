using System.Data;
using GestionRadio.Infrastructure.Persistence;

namespace GestionRadio.Infrastructure.Repositories;

public abstract class BaseRepository
{
    protected readonly SqlConnectionFactory ConnectionFactory;

    protected BaseRepository(SqlConnectionFactory connectionFactory)
    {
        ConnectionFactory = connectionFactory;
    }

    protected IDbConnection CreateConnection()
    {
        return ConnectionFactory.CreateConnection();
    }
}