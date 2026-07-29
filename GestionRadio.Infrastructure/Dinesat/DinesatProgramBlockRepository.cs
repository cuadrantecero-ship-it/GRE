using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Sql;
using Microsoft.Data.SqlClient;

namespace GestionRadio.Infrastructure.Dinesat;

/// <summary>
/// Repositorio de solo lectura para los bloques de programación de Dinesat.
/// Tabla: PROGRAMBLOCK
/// </summary>
public sealed class DinesatProgramBlockRepository : IDinesatProgramBlockRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public DinesatProgramBlockRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory
            ?? throw new ArgumentNullException(nameof(connectionFactory));
    }

    public async Task<IReadOnlyList<DinesatProgramBlock>> ObtenerPorProgramacionAsync(long programmingId)
    {
        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        var bloques = await cn.QueryAsync<DinesatProgramBlock>(
            DinesatProgramBlockSql.ObtenerPorProgramacion,
            new
            {
                ProgrammingId = programmingId
            });

        return bloques.ToList();
    }

    public async Task<DinesatProgramBlock?> ObtenerPorIdAsync(long programBlockId)
    {
        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        return await cn.QueryFirstOrDefaultAsync<DinesatProgramBlock>(
            DinesatProgramBlockSql.ObtenerPorId,
            new
            {
                ProgramBlockId = programBlockId
            });
    }

    public async Task<DinesatProgramBlock?> ObtenerPorHoraAsync(
        long programmingId,
        TimeOnly hora)
    {
        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        return await cn.QueryFirstOrDefaultAsync<DinesatProgramBlock>(
            DinesatProgramBlockSql.ObtenerPorHora,
            new
            {
                ProgrammingId = programmingId,
                Hora = hora.ToString(@"HH\:mm\:ss")
            });
    }
}