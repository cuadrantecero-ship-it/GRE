using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;

namespace GestionRadio.Infrastructure.Dinesat;

public sealed class DinesatMaterialRepository : IDinesatMaterialRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public DinesatMaterialRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    /// <summary>
    /// Obtiene un material por su código.
    /// </summary>
    public async Task<DinesatMaterial?> ObtenerPorCodigoAsync(string codigo)
    {
        const string sql = @"
SELECT
    MATERIALID      AS MaterialIdDinesat,
    CODE            AS Codigo,
    TITLE           AS Titulo,
    LENGTH          AS Duracion,
    MATERIALSTATEID AS MaterialStateId
FROM MATERIAL
WHERE UPPER(CODE) = @Codigo;";

        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        return await cn.QueryFirstOrDefaultAsync<DinesatMaterial>(
            sql,
            new
            {
                Codigo = codigo.Trim().ToUpperInvariant()
            });
    }

    /// <summary>
    /// Obtiene todos los materiales activos.
    /// </summary>
    public async Task<IReadOnlyList<DinesatMaterial>> ObtenerActivosAsync()
    {
        const string sql = @"
SELECT
    MATERIALID      AS MaterialIdDinesat,
    CODE            AS Codigo,
    TITLE           AS Titulo,
    LENGTH          AS Duracion,
    MATERIALSTATEID AS MaterialStateId
FROM MATERIAL
WHERE MATERIALSTATEID = 1
ORDER BY CODE;";

        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        var materiales = await cn.QueryAsync<DinesatMaterial>(sql);

        return materiales.ToList();
    }
}