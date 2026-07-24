using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Sql;

namespace GestionRadio.Infrastructure.Repositories;

public sealed class ClienteRepository : BaseRepository, IClienteRepository
{
    public ClienteRepository(SqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<Cliente>> ObtenerTodosAsync()
    {
        using var db = CreateConnection();

        return await db.QueryAsync<Cliente>(
            ClientesSql.ObtenerTodos);
    }

    public async Task<Cliente?> ObtenerPorIdAsync(long id)
    {
        using var db = CreateConnection();

        return await db.QueryFirstOrDefaultAsync<Cliente>(
            ClientesSql.ObtenerPorId,
            new
            {
                IdCliente = id
            });
    }

    public async Task<Cliente?> ObtenerPorFolioAsync(string folio)
    {
        using var db = CreateConnection();

        return await db.QueryFirstOrDefaultAsync<Cliente>(
            ClientesSql.ObtenerPorFolio,
            new
            {
                Folio = folio
            });
    }

    public async Task<long> InsertarAsync(Cliente cliente)
    {
        using var db = CreateConnection();

        return await db.ExecuteScalarAsync<long>(
            ClientesSql.Insertar,
            cliente);
    }

    public async Task ActualizarAsync(Cliente cliente)
    {
        using var db = CreateConnection();

        await db.ExecuteAsync(
            ClientesSql.Actualizar,
            cliente);
    }

    public async Task CambiarEstadoAsync(long id, bool activo)
    {
        using var db = CreateConnection();

        var filas = await db.ExecuteAsync(
            ClientesSql.CambiarEstado,
            new
            {
                IdCliente = id,
                Activo = activo,
                FechaModificacion = DateTime.UtcNow,
                UsuarioModificacion = 1
            });

        if (filas != 1)
            throw new Exception($"Se esperaban 1 fila afectada y se afectaron {filas}.");
    }

    public async Task<bool> ExisteFolioAsync(string folio)
    {
        using var db = CreateConnection();

        var total = await db.ExecuteScalarAsync<int>(
            ClientesSql.ExisteFolio,
            new
            {
                Folio = folio
            });

        return total > 0;
    }
}