namespace GestionRadio.Infrastructure.Sql;

public static class CampaniasSql
{
    public const string ObtenerTodos = @"
SELECT
    C.ID_CAMPANIA      AS IdCampania,
    C.FOLIO            AS Folio,
    C.ID_CLIENTE       AS IdCliente,
    CL.RAZON_SOCIAL    AS Cliente,
    C.NOMBRE           AS Nombre,
    C.DESCRIPCION      AS Descripcion,
    C.FECHA_INICIO     AS FechaInicio,
    C.FECHA_FIN        AS FechaFin,
    C.PRIORIDAD        AS Prioridad,
    C.ESTADO           AS Estado,
    C.ACTIVO           AS Activo,
    C.FECHA_ALTA       AS FechaAlta
FROM GR_CAMPANIA C
INNER JOIN GR_CLIENTE CL
    ON CL.ID_CLIENTE = C.ID_CLIENTE
WHERE C.ACTIVO = 1
ORDER BY
    CL.RAZON_SOCIAL,
    C.FECHA_INICIO,
    C.NOMBRE;";


    public const string ObtenerPorId = @"
SELECT
    C.ID_CAMPANIA      AS IdCampania,
    C.FOLIO            AS Folio,
    C.ID_CLIENTE       AS IdCliente,
    CL.RAZON_SOCIAL    AS Cliente,
    C.NOMBRE           AS Nombre,
    C.DESCRIPCION      AS Descripcion,
    C.FECHA_INICIO     AS FechaInicio,
    C.FECHA_FIN        AS FechaFin,
    C.PRIORIDAD        AS Prioridad,
    C.ESTADO           AS Estado,
    C.ACTIVO           AS Activo,
    C.FECHA_ALTA       AS FechaAlta
FROM GR_CAMPANIA C
INNER JOIN GR_CLIENTE CL
    ON CL.ID_CLIENTE = C.ID_CLIENTE
WHERE C.ID_CAMPANIA = @IdCampania;";


    public const string Insertar = @"
INSERT INTO GR_CAMPANIA
(
    FOLIO,
    ID_CLIENTE,
    NOMBRE,
    DESCRIPCION,
    FECHA_INICIO,
    FECHA_FIN,
    PRIORIDAD,
    ESTADO,
    ACTIVO,
    FECHA_ALTA,
    USUARIO_ALTA
)
VALUES
(
    @Folio,
    @IdCliente,
    @Nombre,
    @Descripcion,
    @FechaInicio,
    @FechaFin,
    @Prioridad,
    @Estado,
    @Activo,
    @FechaAlta,
    @UsuarioAlta
);

SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";


    public const string Actualizar = @"
UPDATE GR_CAMPANIA
SET
    ID_CLIENTE = @IdCliente,
    NOMBRE = @Nombre,
    DESCRIPCION = @Descripcion,
    FECHA_INICIO = @FechaInicio,
    FECHA_FIN = @FechaFin,
    PRIORIDAD = @Prioridad,
    ESTADO = @Estado,
    FECHA_MODIFICACION = @FechaModificacion,
    USUARIO_MODIFICACION = @UsuarioModificacion
WHERE ID_CAMPANIA = @IdCampania;";


    public const string EliminarLogico = @"
UPDATE GR_CAMPANIA
SET
    ACTIVO = 0,
    FECHA_MODIFICACION = @FechaModificacion,
    USUARIO_MODIFICACION = @UsuarioModificacion
WHERE ID_CAMPANIA = @IdCampania;";


    public const string ExisteFolio = @"
SELECT COUNT(*)
FROM GR_CAMPANIA
WHERE FOLIO = @Folio;";
}