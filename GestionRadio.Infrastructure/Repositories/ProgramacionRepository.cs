using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Sql;

namespace GestionRadio.Infrastructure.Repositories;

public sealed class ProgramacionRepository : BaseRepository, IProgramacionRepository
{
    public ProgramacionRepository(SqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<Programacion>> ObtenerTodosAsync()
    {
        using var connection = CreateConnection();

        return await connection.QueryAsync<Programacion>(
            ProgramacionSql.ObtenerTodos);
    }

    public async Task<Programacion?> ObtenerPorIdAsync(long id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        using var connection = CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<Programacion>(
            ProgramacionSql.ObtenerPorId,
            new { Id = id });
    }

    public async Task<long> InsertarAsync(Programacion programacion)
    {
        ArgumentNullException.ThrowIfNull(programacion);

        using var connection = CreateConnection();

        return await connection.ExecuteScalarAsync<long>(
            ProgramacionSql.Insertar,
            programacion);
    }

    public async Task ActualizarAsync(Programacion programacion)
    {
        ArgumentNullException.ThrowIfNull(programacion);

        using var connection = CreateConnection();

        await connection.ExecuteAsync(
            ProgramacionSql.Actualizar,
            programacion);
    }

    public async Task EliminarLogicoAsync(long id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        using var connection = CreateConnection();

        await connection.ExecuteAsync(
            ProgramacionSql.EliminarLogico,
            new { Id = id });
    }
}