namespace GestionRadio.Infrastructure.Sql;

public static class ParrillasSql
{
    //====================================================
    // PARRILLAS
    //====================================================

    public const string ObtenerTodas = @"
SELECT
    ParrillaId,
    EmisoraId,
    Nombre,
    FechaInicio,
    FechaFin,
    Activa,
    FechaCreacion
FROM GR_PARRILLA
ORDER BY Nombre;";



    public const string ObtenerPorId = @"
SELECT
    ParrillaId,
    EmisoraId,
    Nombre,
    FechaInicio,
    FechaFin,
    Activa,
    FechaCreacion
FROM GR_PARRILLA
WHERE ParrillaId=@Id;";



    public const string Insertar = @"
INSERT INTO GR_PARRILLA
(
    EmisoraId,
    Nombre,
    FechaInicio,
    FechaFin,
    Activa
)
VALUES
(
    @EmisoraId,
    @Nombre,
    @FechaInicio,
    @FechaFin,
    @Activa
);

SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";



    public const string Actualizar = @"
UPDATE GR_PARRILLA
SET
    EmisoraId=@EmisoraId,
    Nombre=@Nombre,
    FechaInicio=@FechaInicio,
    FechaFin=@FechaFin,
    Activa=@Activa
WHERE ParrillaId=@ParrillaId;";



    public const string Eliminar = @"
DELETE
FROM GR_PARRILLA
WHERE ParrillaId=@Id;";




    //====================================================
    // EVENTOS
    //====================================================

    public const string ObtenerEventos = @"
SELECT
    EventoId,
    ParrillaId,
    Hora,
    TipoEventoId,
    Descripcion,
    PermitePublicidad,
    DuracionSegundos,
    DuracionMaximaSegundos,
    Orden
FROM GR_PARRILLA_EVENTO
WHERE ParrillaId=@ParrillaId
ORDER BY Hora, Orden;";



    public const string EliminarEventos = @"
DELETE
FROM GR_PARRILLA_EVENTO
WHERE ParrillaId=@ParrillaId;";



    public const string InsertarEvento = @"

INSERT INTO GR_PARRILLA_EVENTO
(
    ParrillaId,
    Hora,
    TipoEventoId,
    Descripcion,
    PermitePublicidad,
    DuracionMaximaSegundos,
    Orden
)
VALUES
(
    @ParrillaId,
    @Hora,
    @TipoEventoId,
    @Descripcion,
    @PermitePublicidad,
    @DuracionMaximaSegundos,
    @Orden
);";



    //====================================================
    // CRUD EVENTOS INDIVIDUALES
    //====================================================

    public const string ActualizarEvento = @"
UPDATE GR_PARRILLA_EVENTO
SET
    Hora=@Hora,
    TipoEventoId=@TipoEventoId,
    Descripcion=@Descripcion,
    PermitePublicidad=@PermitePublicidad,
    DuracionMaximaSegundos=@DuracionMaximaSegundos,
    Orden=@Orden
WHERE EventoId=@EventoId;";



    public const string EliminarEvento = @"
DELETE
FROM GR_PARRILLA_EVENTO
WHERE EventoId=@EventoId;";




    //====================================================
    // TIMELINE PROGRAMACION
    //====================================================

    public const string ObtenerTimeline = @"
SELECT
    pe.EventoId,
    pe.ParrillaId,
    pe.Hora,
    pe.TipoEventoId,
    pe.Descripcion,
    pe.PermitePublicidad,
    pe.DuracionSegundos,
    pe.DuracionMaximaSegundos,
    pe.Orden

FROM GR_PARRILLA p

INNER JOIN GR_PARRILLA_EVENTO pe
        ON pe.ParrillaId = p.ParrillaId

WHERE
    p.EmisoraId = @EmisoraId

    AND @Fecha BETWEEN p.FechaInicio
                   AND ISNULL(p.FechaFin,'2999-12-31')

    AND p.Activa = 1

ORDER BY
    pe.Hora,
    pe.Orden;";




    //====================================================
    // TIPOS DE EVENTO
    //====================================================

    public const string ObtenerTiposEvento = @"
SELECT
    TipoEventoId,
    Nombre,
    PermitePublicidad,
    Activo
FROM GR_TIPO_EVENTO
WHERE Activo = 1
ORDER BY TipoEventoId;";
}