using System.Data;
using Microsoft.Data.SqlClient;

namespace GestionRadio.Infrastructure.Persistence;

/// <summary>
/// Administra transacciones SQL para garantizar la integridad de las operaciones.
/// </summary>
public sealed class UnitOfWork : IDisposable
{
    private readonly SqlConnectionFactory _connectionFactory;

    private IDbConnection? _connection;
    private IDbTransaction? _transaction;

    public UnitOfWork(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    /// <summary>
    /// Conexión activa.
    /// </summary>
    public IDbConnection Connection
    {
        get
        {
            _connection ??= _connectionFactory.CreateConnection();
            return _connection;
        }
    }

    /// <summary>
    /// Transacción activa.
    /// </summary>
    public IDbTransaction? Transaction => _transaction;

    /// <summary>
    /// Inicia una nueva transacción.
    /// </summary>
    public void Begin()
    {
        if (_connection == null)
        {
            _connection = _connectionFactory.CreateConnection();
            _connection.Open();
        }

        _transaction ??= _connection.BeginTransaction();
    }

    /// <summary>
    /// Confirma los cambios.
    /// </summary>
    public void Commit()
    {
        _transaction?.Commit();
        DisposeTransaction();
    }

    /// <summary>
    /// Cancela los cambios.
    /// </summary>
    public void Rollback()
    {
        _transaction?.Rollback();
        DisposeTransaction();
    }

    private void DisposeTransaction()
    {
        _transaction?.Dispose();
        _transaction = null;
    }

    public void Dispose()
    {
        DisposeTransaction();

        _connection?.Dispose();
        _connection = null;
    }
}