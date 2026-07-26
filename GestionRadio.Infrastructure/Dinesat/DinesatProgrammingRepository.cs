using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;

namespace GestionRadio.Infrastructure.Dinesat;

/// <summary>
/// Repositorio de solo lectura para la tabla PROGRAMMING de Dinesat.
/// </summary>
public sealed class DinesatProgrammingRepository : IDinesatProgrammingRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public DinesatProgrammingRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory
            ?? throw new ArgumentNullException(nameof(connectionFactory));
    }

    public async Task<DinesatProgramming?> ObtenerActivaAsync()
    {
        const string sql = @"
SELECT TOP (1)
    PGMID       AS ProgrammingId,
    STATIONID   AS StationId,
    PGMDATE     AS Fecha,
    PGMTYPE     AS ProgrammingTypeId,
    PGMACTIVE   AS Activa
FROM PROGRAMMING
WHERE PGMACTIVE = 1
ORDER BY PGMDATE DESC;";

        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        return await cn.QueryFirstOrDefaultAsync<DinesatProgramming>(sql);
    }

    public async Task<DinesatProgramming?> ObtenerPorIdAsync(long programmingId)
    {
        const string sql = @"
SELECT
    PGMID       AS ProgrammingId,
    STATIONID   AS StationId,
    PGMDATE     AS Fecha,
    PGMTYPE     AS ProgrammingTypeId,
    PGMACTIVE   AS Activa
FROM PROGRAMMING
WHERE PGMID = @ProgrammingId;";

        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        return await cn.QueryFirstOrDefaultAsync<DinesatProgramming>(
            sql,
            new
            {
                ProgrammingId = programmingId
            });
    }

    public async Task<IReadOnlyList<DinesatProgramming>> ObtenerTodasAsync()
    {
        const string sql = @"
SELECT
    PGMID       AS ProgrammingId,
    STATIONID   AS StationId,
    PGMDATE     AS Fecha,
    PGMTYPE     AS ProgrammingTypeId,
    PGMACTIVE   AS Activa
FROM PROGRAMMING
ORDER BY PGMDATE DESC;";

        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        var resultado = await cn.QueryAsync<DinesatProgramming>(sql);

        return resultado.ToList();
    }

    /// <summary>
    /// Obtiene la programación correspondiente a una fecha y estación.
    /// PGMDATE en Dinesat se almacena como varchar con formato yyyy/MM/dd.
    /// </summary>
    public async Task<DinesatProgramming?> ObtenerPorFechaAsync(
        DateOnly fecha,
        long stationId)
    {
        const string sql = @"
SELECT TOP (1)
    PGMID       AS ProgrammingId,
    STATIONID   AS StationId,
    PGMDATE     AS Fecha,
    PGMTYPE     AS ProgrammingTypeId,
    PGMACTIVE   AS Activa
FROM PROGRAMMING
WHERE PGMDATE = @Fecha
  AND STATIONID = @StationId
ORDER BY PGMID;";

        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        return await cn.QueryFirstOrDefaultAsync<DinesatProgramming>(
            sql,
            new
            {
                Fecha = fecha.ToString("yyyy/MM/dd"),
                StationId = stationId
            });
    }
}