using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Sql;

namespace GestionRadio.Infrastructure.Repositories;

public sealed class DinesatProgramEventRepository
    : BaseRepository, IDinesatProgramEventRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public DinesatProgramEventRepository(
        SqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }


    public async Task<IReadOnlyList<DinesatProgramEvent>> ObtenerPorBloqueAsync(
        long programBlockId)
    {
        if (programBlockId <= 0)
            throw new ArgumentOutOfRangeException(nameof(programBlockId));

        using var connection = _connectionFactory.CreateDinesatConnection();

        var resultado = await connection.QueryAsync<DinesatProgramEvent>(
            DinesatProgramEventSql.ObtenerPorBloque,
            new
            {
                ProgramBlockId = programBlockId
            });

        return resultado.ToList();
    }


    public async Task<DinesatProgramEvent?> ObtenerPorIdAsync(
        long programEventId)
    {
        if (programEventId <= 0)
            throw new ArgumentOutOfRangeException(nameof(programEventId));

        using var connection = _connectionFactory.CreateDinesatConnection();

        return await connection.QueryFirstOrDefaultAsync<DinesatProgramEvent>(
            DinesatProgramEventSql.ObtenerPorId,
            new
            {
                Id = programEventId
            });
    }


    public async Task<int> ObtenerSiguienteItemOrderAsync(
        long programBlockId)
    {
        if (programBlockId <= 0)
            throw new ArgumentOutOfRangeException(nameof(programBlockId));

        using var connection = _connectionFactory.CreateDinesatConnection();

        return await connection.ExecuteScalarAsync<int>(
            DinesatProgramEventSql.ObtenerSiguienteItemOrder,
            new
            {
                ProgramBlockId = programBlockId
            });
    }


    public async Task<long> InsertarAsync(
        DinesatProgramEvent evento)
    {
        ArgumentNullException.ThrowIfNull(evento);

        using var connection = _connectionFactory.CreateDinesatConnection();

        return await connection.ExecuteScalarAsync<long>(
            DinesatProgramEventSql.Insertar,
            evento);
    }
}