using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;

namespace GestionRadio.Infrastructure.Dinesat;

/// <summary>
/// Repositorio de solo lectura para los eventos de programación de Dinesat.
/// Tabla: PROGRAMEVENT.
/// </summary>
public sealed class DinesatProgramEventRepository : IDinesatProgramEventRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public DinesatProgramEventRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    /// <summary>
    /// Obtiene todos los eventos pertenecientes a un bloque.
    /// Incluye la información del material mediante JOIN.
    /// </summary>
    public async Task<IReadOnlyList<DinesatProgramEvent>> ObtenerPorBloqueAsync(long programBlockId)
    {
        const string sql = @"
SELECT
    PE.PGMEVENTID                     AS ProgramEventId,
    PE.PGMBLOCKID                     AS ProgramBlockId,
    PE.ITEMORDER                      AS ItemOrder,
    PE.MATERIALID                     AS MaterialId,

    M.CODE                            AS MaterialCode,
    M.TITLE                           AS MaterialTitle,
    (M.ENDPOS - M.STARTPOS)           AS LengthFrames,

    PE.CONDITION                      AS Condition,
    PE.TRAFFICCODE                    AS TrafficCode,
    PE.TRAFFICINDEX                   AS TrafficIndex,
    PE.LIVEDESC                       AS LiveDescription,
    PE.LIVELENGTH                     AS LiveLength

FROM PROGRAMEVENT PE
LEFT JOIN MATERIAL M
    ON PE.MATERIALID = M.MATERIALID

WHERE PE.PGMBLOCKID = @ProgramBlockId
ORDER BY PE.ITEMORDER;";

        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        var eventos = await cn.QueryAsync<DinesatProgramEvent>(
            sql,
            new
            {
                ProgramBlockId = programBlockId
            });

        return eventos.ToList();
    }

    /// <summary>
    /// Obtiene un evento por su identificador.
    /// Incluye la información del material.
    /// </summary>
    public async Task<DinesatProgramEvent?> ObtenerPorIdAsync(long programEventId)
    {
        const string sql = @"
SELECT
    PE.PGMEVENTID                     AS ProgramEventId,
    PE.PGMBLOCKID                     AS ProgramBlockId,
    PE.ITEMORDER                      AS ItemOrder,
    PE.MATERIALID                     AS MaterialId,

    M.CODE                            AS MaterialCode,
    M.TITLE                           AS MaterialTitle,
    (M.ENDPOS - M.STARTPOS)           AS LengthFrames,

    PE.CONDITION                      AS Condition,
    PE.TRAFFICCODE                    AS TrafficCode,
    PE.TRAFFICINDEX                   AS TrafficIndex,
    PE.LIVEDESC                       AS LiveDescription,
    PE.LIVELENGTH                     AS LiveLength

FROM PROGRAMEVENT PE
LEFT JOIN MATERIAL M
    ON PE.MATERIALID = M.MATERIALID

WHERE PE.PGMEVENTID = @ProgramEventId;";

        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        return await cn.QueryFirstOrDefaultAsync<DinesatProgramEvent>(
            sql,
            new
            {
                ProgramEventId = programEventId
            });
    }
}