using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
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
    MATERIALID      AS MaterialIdDinesat,
    CODE            AS Codigo,
    TITLE           AS Titulo,
    LENGTH          AS Duracion,
    MATERIALSTATEID AS MaterialStateId
FROM MATERIAL
WHERE CODE = @Codigo;";

        using var cn = (SqlConnection)_connectionFactory.CreateDinesatConnection();

        await cn.OpenAsync();

        Console.WriteLine("==========================================");
        Console.WriteLine("PRUEBA CONEXIÓN DINESAT");
        Console.WriteLine("Servidor : " + cn.DataSource);
        Console.WriteLine("Base     : " + cn.Database);
        Console.WriteLine("Código   : " + codigo.Trim().ToUpperInvariant());
        Console.WriteLine("==========================================");

        var material = await cn.QueryFirstOrDefaultAsync<DinesatMaterial>(
            sql,
            new
            {
                Codigo = codigo.Trim().ToUpperInvariant()
            });

        if (material == null)
        {
            Console.WriteLine("RESULTADO : MATERIAL NO ENCONTRADO");
        }
        else
        {
            Console.WriteLine("RESULTADO : MATERIAL ENCONTRADO");
            Console.WriteLine("ID        : " + material.MaterialIdDinesat);
            Console.WriteLine("TÍTULO    : " + material.Titulo);
            Console.WriteLine("CÓDIGO    : " + material.Codigo);
        }

        return material;
    }

    //=========================================================
    // OBTENER TODOS LOS MATERIALES ACTIVOS
    //=========================================================

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