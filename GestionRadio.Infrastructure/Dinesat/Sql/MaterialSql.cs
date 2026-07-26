namespace GestionRadio.Infrastructure.Dinesat.Sql;

internal static class MaterialSql
{
    /// <summary>
    /// Obtiene un material por su código (ej. SPO00003).
    /// </summary>
    public const string ObtenerPorCodigo = @"
SELECT
    MATERIALID,
    TITLE,
    CODE,
    MATERIALSTATEID,
    ASSETTYPEID,
    MEDIATYPEID,
    LENGTH
FROM MATERIAL
WHERE CODE = @Codigo;";

    /// <summary>
    /// Obtiene todos los materiales activos.
    /// </summary>
    public const string ObtenerActivos = @"
SELECT
    MATERIALID,
    TITLE,
    CODE,
    MATERIALSTATEID,
    ASSETTYPEID,
    MEDIATYPEID,
    LENGTH
FROM MATERIAL
WHERE MATERIALSTATEID = 1
ORDER BY CODE;";

    /// <summary>
    /// Obtiene un material por su identificador.
    /// </summary>
    public const string ObtenerPorId = @"
SELECT
    MATERIALID,
    TITLE,
    CODE,
    MATERIALSTATEID,
    ASSETTYPEID,
    MEDIATYPEID,
    LENGTH
FROM MATERIAL
WHERE MATERIALID = @MaterialId;";
}