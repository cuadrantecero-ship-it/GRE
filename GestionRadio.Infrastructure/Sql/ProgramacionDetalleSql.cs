namespace GestionRadio.Infrastructure.Sql;

public static class ProgramacionDetalleSql
{
    public const string ObtenerPorProgramacion = @"
SELECT
    ID_PROGRAMACION_DETALLE          AS ProgramacionDetalleId,
    ID_PROGRAMACION                  AS ProgramacionId,
    ID_CLIENTE                       AS ClienteId,
    ID_CAMPANIA                      AS CampaniaId,
    ID_VERSION                       AS VersionId,
    ID_EVENTO_PARRILLA               AS EventoParrillaId,
    ORDEN                            AS Orden,
    HORA                             AS Hora,
    PROGRAMBLOCK_ID_DINESAT          AS DinesatProgramBlockId,
    PROGRAMEVENT_ID_DINESAT          AS DinesatProgramEventId,
    MATERIAL_ID_DINESAT              AS DinesatMaterialId,
    CODIGO_MATERIAL                  AS CodigoMaterial,
    TITULO_MATERIAL                  AS TituloMaterial,
    DURACION_SEGUNDOS                AS DuracionSegundos,
    ESTADO                           AS Estado,
    TRANSMITIDO                      AS Transmitido,
    SINCRONIZADO                     AS Sincronizado,
    ACTIVO                           AS Activo,
    FECHA_CREACION                   AS FechaCreacion,
    USUARIO_CREACION                 AS UsuarioCreacion,
    FECHA_MODIFICACION               AS FechaModificacion,
    USUARIO_MODIFICACION             AS UsuarioModificacion
FROM GR_PROGRAMACION_DETALLE
WHERE ID_PROGRAMACION = @ProgramacionId
  AND ACTIVO = 1
ORDER BY HORA, ORDEN;";


    public const string ObtenerPorId = @"
SELECT
    ID_PROGRAMACION_DETALLE          AS ProgramacionDetalleId,
    ID_PROGRAMACION                  AS ProgramacionId,
    ID_CLIENTE                       AS ClienteId,
    ID_CAMPANIA                      AS CampaniaId,
    ID_VERSION                       AS VersionId,
    ID_EVENTO_PARRILLA               AS EventoParrillaId,
    ORDEN                            AS Orden,
    HORA                             AS Hora,
    PROGRAMBLOCK_ID_DINESAT          AS DinesatProgramBlockId,
    PROGRAMEVENT_ID_DINESAT          AS DinesatProgramEventId,
    MATERIAL_ID_DINESAT              AS DinesatMaterialId,
    CODIGO_MATERIAL                  AS CodigoMaterial,
    TITULO_MATERIAL                  AS TituloMaterial,
    DURACION_SEGUNDOS                AS DuracionSegundos,
    ESTADO                           AS Estado,
    TRANSMITIDO                      AS Transmitido,
    SINCRONIZADO                     AS Sincronizado,
    ACTIVO                           AS Activo,
    FECHA_CREACION                   AS FechaCreacion,
    USUARIO_CREACION                 AS UsuarioCreacion,
    FECHA_MODIFICACION               AS FechaModificacion,
    USUARIO_MODIFICACION             AS UsuarioModificacion
FROM GR_PROGRAMACION_DETALLE
WHERE ID_PROGRAMACION_DETALLE = @Id;";


    public const string Insertar = @"
INSERT INTO GR_PROGRAMACION_DETALLE
(
    ID_PROGRAMACION,
    ID_EVENTO_PARRILLA,
    ID_CLIENTE,
    ID_CAMPANIA,
    ID_VERSION,
    ORDEN,
    HORA,
    PROGRAMBLOCK_ID_DINESAT,
    PROGRAMEVENT_ID_DINESAT,
    MATERIAL_ID_DINESAT,
    CODIGO_MATERIAL,
    TITULO_MATERIAL,
    DURACION_SEGUNDOS,
    ESTADO,
    TRANSMITIDO,
    SINCRONIZADO,
    ACTIVO,
    USUARIO_CREACION
)
VALUES
(
    @ProgramacionId,
    @EventoParrillaId,
    @ClienteId,
    @CampaniaId,
    @VersionId,
    @Orden,
    @Hora,
    @DinesatProgramBlockId,
    @DinesatProgramEventId,
    @DinesatMaterialId,
    @CodigoMaterial,
    @TituloMaterial,
    @DuracionSegundos,
    @Estado,
    @Transmitido,
    @Sincronizado,
    @Activo,
    @UsuarioCreacion
);

SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";


    public const string Actualizar = @"
UPDATE GR_PROGRAMACION_DETALLE
SET
    ID_EVENTO_PARRILLA = @EventoParrillaId,
    ORDEN = @Orden,
    HORA = @Hora,
    PROGRAMBLOCK_ID_DINESAT = @DinesatProgramBlockId,
    PROGRAMEVENT_ID_DINESAT = @DinesatProgramEventId,
    MATERIAL_ID_DINESAT = @DinesatMaterialId,
    CODIGO_MATERIAL = @CodigoMaterial,
    TITULO_MATERIAL = @TituloMaterial,
    DURACION_SEGUNDOS = @DuracionSegundos,
    ESTADO = @Estado,
    TRANSMITIDO = @Transmitido,
    SINCRONIZADO = @Sincronizado,
    ACTIVO = @Activo,
    FECHA_MODIFICACION = SYSDATETIME(),
    USUARIO_MODIFICACION = @UsuarioModificacion
WHERE ID_PROGRAMACION_DETALLE = @ProgramacionDetalleId;";


    public const string EliminarLogico = @"
UPDATE GR_PROGRAMACION_DETALLE
SET
    ACTIVO = 0,
    FECHA_MODIFICACION = SYSDATETIME()
WHERE ID_PROGRAMACION_DETALLE = @Id;";
}