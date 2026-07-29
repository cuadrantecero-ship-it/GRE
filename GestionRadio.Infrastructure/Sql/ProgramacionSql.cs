namespace GestionRadio.Infrastructure.Sql;

public static class ProgramacionSql
{
    public const string ObtenerTodos = @"
SELECT
    ID_PROGRAMACION            AS ProgramacionId,
    ID_EMISORA                 AS EmisoraId,
    ID_PARRILLA                AS ParrillaId,
    FECHA                      AS Fecha,
    PROGRAMMING_ID_DINESAT     AS DinesatProgrammingId,
    ESTADO                     AS Estado,
    ACTIVA                     AS Activa,
    FECHA_CREACION             AS FechaCreacion,
    USUARIO_CREACION           AS UsuarioCreacion,
    FECHA_MODIFICACION         AS FechaModificacion,
    USUARIO_MODIFICACION       AS UsuarioModificacion
FROM GR_PROGRAMACION
ORDER BY FECHA DESC, ID_PROGRAMACION DESC;";


    public const string ObtenerPorId = @"
SELECT
    ID_PROGRAMACION            AS ProgramacionId,
    ID_EMISORA                 AS EmisoraId,
    ID_PARRILLA                AS ParrillaId,
    FECHA                      AS Fecha,
    PROGRAMMING_ID_DINESAT     AS DinesatProgrammingId,
    ESTADO                     AS Estado,
    ACTIVA                     AS Activa,
    FECHA_CREACION             AS FechaCreacion,
    USUARIO_CREACION           AS UsuarioCreacion,
    FECHA_MODIFICACION         AS FechaModificacion,
    USUARIO_MODIFICACION       AS UsuarioModificacion
FROM GR_PROGRAMACION
WHERE ID_PROGRAMACION = @Id;";


    public const string ObtenerPorFecha = @"
SELECT
    ID_PROGRAMACION            AS ProgramacionId,
    ID_EMISORA                 AS EmisoraId,
    ID_PARRILLA                AS ParrillaId,
    FECHA                      AS Fecha,
    PROGRAMMING_ID_DINESAT     AS DinesatProgrammingId,
    ESTADO                     AS Estado,
    ACTIVA                     AS Activa,
    FECHA_CREACION             AS FechaCreacion,
    USUARIO_CREACION           AS UsuarioCreacion,
    FECHA_MODIFICACION         AS FechaModificacion,
    USUARIO_MODIFICACION       AS UsuarioModificacion
FROM GR_PROGRAMACION
WHERE FECHA = @Fecha
ORDER BY ID_PROGRAMACION;";


    public const string Insertar = @"
INSERT INTO GR_PROGRAMACION
(
    ID_EMISORA,
    ID_PARRILLA,
    FECHA,
    PROGRAMMING_ID_DINESAT,
    ESTADO,
    ACTIVA,
    USUARIO_CREACION
)
VALUES
(
    @EmisoraId,
    @ParrillaId,
    @Fecha,
    @DinesatProgrammingId,
    @Estado,
    @Activa,
    @UsuarioCreacion
);

SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";


    public const string Actualizar = @"
UPDATE GR_PROGRAMACION
SET
    ID_EMISORA = @EmisoraId,
    ID_PARRILLA = @ParrillaId,
    FECHA = @Fecha,
    PROGRAMMING_ID_DINESAT = @DinesatProgrammingId,
    ESTADO = @Estado,
    ACTIVA = @Activa,
    FECHA_MODIFICACION = SYSDATETIME(),
    USUARIO_MODIFICACION = @UsuarioModificacion
WHERE ID_PROGRAMACION = @ProgramacionId;";


    public const string EliminarLogico = @"
UPDATE GR_PROGRAMACION
SET
    ACTIVA = 0,
    FECHA_MODIFICACION = SYSDATETIME()
WHERE ID_PROGRAMACION = @Id;";
}