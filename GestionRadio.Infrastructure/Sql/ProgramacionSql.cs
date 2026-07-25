namespace GestionRadio.Infrastructure.Sql;

public static class ProgramacionSql
{
    public const string ObtenerTodos = @"
SELECT
    ID_PROGRAMACION,
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
    FECHA_ALTA,
    USUARIO_ALTA,
    FECHA_MODIFICACION,
    USUARIO_MODIFICACION
FROM GR_PROGRAMACION
ORDER BY FECHA_PROGRAMACION, HORA_PROGRAMADA, ORDEN;";

    public const string ObtenerPorId = @"
SELECT
    ID_PROGRAMACION,
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
    FECHA_ALTA,
    USUARIO_ALTA,
    FECHA_MODIFICACION,
    USUARIO_MODIFICACION
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
    FECHA_ALTA,
    USUARIO_ALTA
)
VALUES
(
    @IdCampania,
    @IdVersion,
    @IdEmisora,
    @FechaProgramacion,
    @HoraProgramada,
    @MaterialIdDinesat,
    @CodigoMaterial,
    @TituloMaterial,
    @DuracionSegundos,
    @Orden,
    @Transmitido,
    @Activo,
    @FechaAlta,
    @UsuarioAlta
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
    FECHA_MODIFICACION = @FechaModificacion,
    USUARIO_MODIFICACION = @UsuarioModificacion
WHERE ID_PROGRAMACION = @IdProgramacion;";

    public const string EliminarLogico = @"
UPDATE GR_PROGRAMACION
SET
    ACTIVO = 0,
    FECHA_MODIFICACION = GETDATE()
WHERE ID_PROGRAMACION = @Id;";
}