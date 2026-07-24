using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Sql;

namespace GestionRadio.Infrastructure.Repositories;

public sealed class VersionRepository : BaseRepository, IVersionRepository
{
    public VersionRepository(SqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<VersionCampania>> ObtenerTodosAsync()
    {
        using var db = CreateConnection();

        return await db.QueryAsync<VersionCampania>(
            VersionesSql.ObtenerTodos);
    }

    public async Task<VersionCampania?> ObtenerPorIdAsync(long id)
    {
        using var db = CreateConnection();

        return await db.QueryFirstOrDefaultAsync<VersionCampania>(
            VersionesSql.ObtenerPorId,
            new
            {
                IdVersion = id
            });
    }

    public async Task<long> InsertarAsync(VersionCampania version)
    {
        using var db = CreateConnection();

        return await db.ExecuteScalarAsync<long>(
            VersionesSql.Insertar,
            version);
    }

    public async Task ActualizarAsync(VersionCampania version)
    {
        using var db = CreateConnection();

        await db.ExecuteAsync(
            VersionesSql.Actualizar,
            version);
    }

    public async Task EliminarLogicoAsync(long id)
    {
        using var db = CreateConnection();

        await db.ExecuteAsync(
            VersionesSql.EliminarLogico,
            new
            {
                IdVersion = id,
                FechaModificacion = DateTime.UtcNow,
                UsuarioModificacion = "ADMIN"
            });
    }
}