namespace GestionRadio.Infrastructure.Sql;

public static class VersionesSql
{
    public const string ObtenerTodos = @"
SELECT
    ID_VERSION              AS IdVersion,
    ID_CAMPANIA             AS IdCampania,
    MATERIAL_ID_DINESAT     AS MaterialIdDinesat,
    CODIGO_MATERIAL         AS CodigoMaterial,
    TITULO_MATERIAL         AS TituloMaterial,
    DURACION_SEGUNDOS       AS DuracionSegundos,
    ORDEN_ROTACION          AS OrdenRotacion,
    PREFERENTE              AS Preferente,
    ACTIVO                  AS Activo,
    FECHA_ALTA              AS FechaAlta,
    USUARIO_ALTA            AS UsuarioAlta
FROM GR_VERSION
WHERE ACTIVO = 1
ORDER BY ORDEN_ROTACION;
";

    public const string ObtenerPorId = @"
SELECT
    ID_VERSION              AS IdVersion,
    ID_CAMPANIA             AS IdCampania,
    MATERIAL_ID_DINESAT     AS MaterialIdDinesat,
    CODIGO_MATERIAL         AS CodigoMaterial,
    TITULO_MATERIAL         AS TituloMaterial,
    DURACION_SEGUNDOS       AS DuracionSegundos,
    ORDEN_ROTACION          AS OrdenRotacion,
    PREFERENTE              AS Preferente,
    ACTIVO                  AS Activo,
    FECHA_ALTA              AS FechaAlta,
    USUARIO_ALTA            AS UsuarioAlta,
    FECHA_MODIFICACION      AS FechaModificacion,
    USUARIO_MODIFICACION    AS UsuarioModificacion
FROM GR_VERSION
WHERE ID_VERSION = @IdVersion;
";

    public const string ObtenerPorCampania = @"
SELECT
    ID_VERSION              AS IdVersion,
    ID_CAMPANIA             AS IdCampania,
    MATERIAL_ID_DINESAT     AS MaterialIdDinesat,
    CODIGO_MATERIAL         AS CodigoMaterial,
    TITULO_MATERIAL         AS TituloMaterial,
    DURACION_SEGUNDOS       AS DuracionSegundos,
    ORDEN_ROTACION          AS OrdenRotacion,
    PREFERENTE              AS Preferente,
    ACTIVO                  AS Activo,
    FECHA_ALTA              AS FechaAlta,
    USUARIO_ALTA            AS UsuarioAlta,
    FECHA_MODIFICACION      AS FechaModificacion,
    USUARIO_MODIFICACION    AS UsuarioModificacion
FROM GR_VERSION
WHERE ID_CAMPANIA = @IdCampania
  AND ACTIVO = 1
ORDER BY
    PREFERENTE DESC,
    ORDEN_ROTACION ASC;
";

    public const string Insertar = @"
INSERT INTO GR_VERSION
(
    ID_CAMPANIA,
    MATERIAL_ID_DINESAT,
    CODIGO_MATERIAL,
    TITULO_MATERIAL,
    DURACION_SEGUNDOS,
    ORDEN_ROTACION,
    PREFERENTE,
    ACTIVO,
    FECHA_ALTA,
    USUARIO_ALTA
)
VALUES
(
    @IdCampania,
    @MaterialIdDinesat,
    @CodigoMaterial,
    @TituloMaterial,
    @DuracionSegundos,
    @OrdenRotacion,
    @Preferente,
    @Activo,
    @FechaAlta,
    @UsuarioAlta
);

SELECT CAST(SCOPE_IDENTITY() AS BIGINT);
";

    public const string Actualizar = @"
UPDATE GR_VERSION
SET
    ORDEN_ROTACION = @OrdenRotacion,
    PREFERENTE = @Preferente,
    ACTIVO = @Activo,
    FECHA_MODIFICACION = @FechaModificacion,
    USUARIO_MODIFICACION = @UsuarioModificacion
WHERE ID_VERSION = @IdVersion;
";

    public const string EliminarLogico = @"
UPDATE GR_VERSION
SET
    ACTIVO = 0,
    FECHA_MODIFICACION = @FechaModificacion,
    USUARIO_MODIFICACION = @UsuarioModificacion
WHERE ID_VERSION = @IdVersion;
";
}