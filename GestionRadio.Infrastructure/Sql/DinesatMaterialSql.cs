namespace GestionRadio.Infrastructure.Sql;

public static class DinesatMaterialSql
{
    public const string ObtenerPorCodigo = @"
SELECT
    MATERIALID      AS MaterialIdDinesat,
    CODE            AS Codigo,
    TITLE           AS Titulo,
    LENGTH          AS Duracion,
    MATERIALSTATEID AS MaterialStateId
FROM MATERIAL
WHERE CODE = @Codigo;";

    public const string ObtenerActivos = @"
SELECT
    MATERIALID      AS MaterialIdDinesat,
    CODE            AS Codigo,
    TITLE           AS Titulo,
    LENGTH          AS Duracion,
    MATERIALSTATEID AS MaterialStateId
FROM MATERIAL
WHERE MATERIALSTATEID = 1
ORDER BY CODE;";
}