namespace GestionRadio.Infrastructure.Sql;

public static class ProgramacionSql
{
    public const string ObtenerTodos = @"
SELECT
    ID_PROGRAMACION       AS ProgramacionId,
    ID_CAMPANIA           AS CampaniaId,
    ID_VERSION            AS VersionId,
    ID_EMISORA            AS EmisoraId,
    FECHA_PROGRAMACION    AS FechaProgramacion,
    HORA_PROGRAMADA       AS HoraProgramada,
    MATERIAL_ID_DINESAT   AS MaterialIdDinesat,
    CODIGO_MATERIAL       AS CodigoMaterial,
    TITULO_MATERIAL       AS TituloMaterial,
    DURACION_SEGUNDOS     AS DuracionSegundos,
    ORDEN                 AS Orden,
    TRANSMITIDO           AS Transmitido,
    ACTIVO                AS Activo,
    FECHA_ALTA            AS FechaCreacion,
    USUARIO_ALTA          AS UsuarioCreacion,
    FECHA_MODIFICACION    AS FechaModificacion,
    USUARIO_MODIFICACION  AS UsuarioModificacion
FROM GR_PROGRAMACION
ORDER BY FECHA_PROGRAMACION DESC, HORA_PROGRAMADA;";

    public const string ObtenerPorFecha = @"
SELECT
    ID_PROGRAMACION       AS ProgramacionId,
    ID_CAMPANIA           AS CampaniaId,
    ID_VERSION            AS VersionId,
    ID_EMISORA            AS EmisoraId,
    FECHA_PROGRAMACION    AS FechaProgramacion,
    HORA_PROGRAMADA       AS HoraProgramada,
    MATERIAL_ID_DINESAT   AS MaterialIdDinesat,
    CODIGO_MATERIAL       AS CodigoMaterial,
    TITULO_MATERIAL       AS TituloMaterial,
    DURACION_SEGUNDOS     AS DuracionSegundos,
    ORDEN                 AS Orden,
    TRANSMITIDO           AS Transmitido,
    ACTIVO                AS Activo,
    FECHA_ALTA            AS FechaCreacion,
    USUARIO_ALTA          AS UsuarioCreacion,
    FECHA_MODIFICACION    AS FechaModificacion,
    USUARIO_MODIFICACION  AS UsuarioModificacion
FROM GR_PROGRAMACION
WHERE FECHA_PROGRAMACION = @Fecha
AND ACTIVO = 1
ORDER BY HORA_PROGRAMADA, ORDEN;";


    public const string ObtenerPorId = @"
SELECT
    ID_PROGRAMACION       AS ProgramacionId,
    ID_CAMPANIA           AS CampaniaId,
    ID_VERSION            AS VersionId,
    ID_EMISORA            AS EmisoraId,
    FECHA_PROGRAMACION    AS FechaProgramacion,
    HORA_PROGRAMADA       AS HoraProgramada,
    MATERIAL_ID_DINESAT   AS MaterialIdDinesat,
    CODIGO_MATERIAL       AS CodigoMaterial,
    TITULO_MATERIAL       AS TituloMaterial,
    DURACION_SEGUNDOS     AS DuracionSegundos,
    ORDEN                 AS Orden,
    TRANSMITIDO           AS Transmitido,
    ACTIVO                AS Activo,
    FECHA_ALTA            AS FechaCreacion,
    USUARIO_ALTA          AS UsuarioCreacion,
    FECHA_MODIFICACION    AS FechaModificacion,
    USUARIO_MODIFICACION  AS UsuarioModificacion
FROM GR_PROGRAMACION
WHERE ID_PROGRAMACION = @Id;";


    public const string Insertar = @"
INSERT INTO GR_PROGRAMACION
(
    ID_CAMPANIA,
    ID_VERSION,
    ID_EMISORA,
    FECHA_PROGRAMACION,
    HORA_PROGRAMADA,
    MATERIAL_ID_DINESAT,
    CODIGO_MATERIAL,
    TITULO_MATERIAL,
    DURACION_SEGUNDOS,
    ORDEN,
    TRANSMITIDO,
    ACTIVO,
    USUARIO_ALTA
)
VALUES
(
    @CampaniaId,
    @VersionId,
    @EmisoraId,
    @FechaProgramacion,
    @HoraProgramada,
    @MaterialIdDinesat,
    @CodigoMaterial,
    @TituloMaterial,
    @DuracionSegundos,
    @Orden,
    @Transmitido,
    @Activo,
    @UsuarioCreacion
);

SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";


    public const string Actualizar = @"
UPDATE GR_PROGRAMACION
SET
    FECHA_PROGRAMACION = @FechaProgramacion,
    HORA_PROGRAMADA = @HoraProgramada,
    ORDEN = @Orden,
    TRANSMITIDO = @Transmitido,
    ACTIVO = @Activo,
    FECHA_MODIFICACION = SYSDATETIME(),
    USUARIO_MODIFICACION = @UsuarioModificacion
WHERE ID_PROGRAMACION = @ProgramacionId;";


    public const string EliminarLogico = @"
UPDATE GR_PROGRAMACION
SET
    ACTIVO = 0,
    FECHA_MODIFICACION = SYSDATETIME()
WHERE ID_PROGRAMACION = @Id;";
}