using System.Data;
using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;

namespace GestionRadio.Infrastructure.Dinesat;

public sealed class DinesatMaterialRepository : IDinesatMaterialRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public DinesatMaterialRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    //=========================================================
    // OBTENER MATERIAL POR CÓDIGO
    //=========================================================

    public async Task<DinesatMaterial?> ObtenerPorCodigoAsync(string codigo)
    {
        const string sql = @"
SELECT
    MATERIALID      AS MaterialId,
    CODE            AS Codigo,
    TITLE           AS Titulo,
    LENGTH          AS Duracion,
    MATERIALSTATEID AS MaterialStateId
FROM MATERIAL
WHERE CODE = @Codigo;";

        using IDbConnection cn = _connectionFactory.CreateDinesatConnection();

        return await cn.QueryFirstOrDefaultAsync<DinesatMaterial>(
            sql,
            new
            {
                Codigo = codigo.Trim().ToUpperInvariant()
            });
    }

    //=========================================================
    // OBTENER TODOS LOS MATERIALES ACTIVOS
    //=========================================================

    public async Task<IReadOnlyList<DinesatMaterial>> ObtenerActivosAsync()
    {
        const string sql = @"
SELECT
    MATERIALID      AS MaterialId,
    CODE            AS Codigo,
    TITLE           AS Titulo,
    LENGTH          AS Duracion,
    MATERIALSTATEID AS MaterialStateId
FROM MATERIAL
WHERE MATERIALSTATEID = 1
ORDER BY CODE;";

        using IDbConnection cn = _connectionFactory.CreateDinesatConnection();

        var materiales = await cn.QueryAsync<DinesatMaterial>(sql);

        return materiales.ToList();
    }
}