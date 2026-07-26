using System.Data;

namespace GestionRadio.Infrastructure.Persistence;

public abstract class BaseRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    protected BaseRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    protected IDbConnection CreateConnection()
    {
        return _connectionFactory.CreateGestionRadioConnection();
    }

    protected IDbConnection CreateDinesatConnection()
    {
        return _connectionFactory.CreateDinesatConnection();
    }
}