using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
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
        const string sql = @"
SELECT
    PGMBLOCKID  AS ProgramBlockId,
    PGMID       AS ProgrammingId,
    BLOCKTIME   AS HoraInicio,
    DESCRIPTION AS Nombre
FROM PROGRAMBLOCK
WHERE PGMID = @ProgrammingId
ORDER BY BLOCKTIME;";

        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        var bloques = await cn.QueryAsync<DinesatProgramBlock>(
            sql,
            new
            {
                ProgrammingId = programmingId
            });

        return bloques.ToList();
    }

    public async Task<DinesatProgramBlock?> ObtenerPorIdAsync(long programBlockId)
    {
        const string sql = @"
SELECT
    PGMBLOCKID  AS ProgramBlockId,
    PGMID       AS ProgrammingId,
    BLOCKTIME   AS HoraInicio,
    DESCRIPTION AS Nombre
FROM PROGRAMBLOCK
WHERE PGMBLOCKID = @ProgramBlockId;";

        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        return await cn.QueryFirstOrDefaultAsync<DinesatProgramBlock>(
            sql,
            new
            {
                ProgramBlockId = programBlockId
            });
    }
}