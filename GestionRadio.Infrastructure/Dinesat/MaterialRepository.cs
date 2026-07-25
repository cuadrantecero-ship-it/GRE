using Dapper;
using GestionRadio.Infrastructure.Persistence;

namespace GestionRadio.Infrastructure.Dinesat;

public sealed class MaterialRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public MaterialRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<MaterialDinesat>> ObtenerMaterialesAsync()
    {
        const string sql = @"
SELECT
    MATERIALID      AS MaterialId,
    CODE            AS Codigo,
    TITLE           AS Titulo,
    LENGTH          AS Duracion,
    MATERIALSTATEID
FROM MATERIAL
WHERE MATERIALSTATEID = 1
ORDER BY CODE;";

        using var cn = _connectionFactory.CreateConnection("DinesatRadio9");

        return await cn.QueryAsync<MaterialDinesat>(sql);
    }

    //==================================================
    // BUSCAR MATERIAL POR CÓDIGO
    //==================================================

    public async Task<MaterialDinesat?> ObtenerPorCodigoAsync(string codigo)
    {
        const string sql = @"
SELECT TOP (1)
    MATERIALID      AS MaterialId,
    CODE            AS Codigo,
    TITLE           AS Titulo,
    LENGTH          AS Duracion,
    MATERIALSTATEID
FROM MATERIAL
WHERE
    CODE = @Codigo
    AND MATERIALSTATEID = 1;";

        using var cn = _connectionFactory.CreateConnection("DinesatRadio9");

        return await cn.QueryFirstOrDefaultAsync<MaterialDinesat>(
            sql,
            new
            {
                Codigo = codigo.Trim().ToUpper()
            });
    }
}