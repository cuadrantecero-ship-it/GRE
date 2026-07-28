namespace GestionRadio.Infrastructure.Sql;

public static class EmisoraSql
{
    public const string ObtenerTodas = @"
SELECT
    ID_EMISORA              AS EmisoraId,
    SIGLAS                  AS Siglas,
    NOMBRE                  AS Nombre,
    DINESAT_STATION_ID      AS DinesatStationId,
    ACTIVA                  AS Activa,
    FECHA_ALTA              AS FechaAlta,
    USUARIO_ALTA            AS UsuarioAlta
FROM GR_EMISORA
ORDER BY NOMBRE;";


    public const string ObtenerActivas = @"
SELECT
    ID_EMISORA              AS EmisoraId,
    SIGLAS                  AS Siglas,
    NOMBRE                  AS Nombre,
    DINESAT_STATION_ID      AS DinesatStationId,
    ACTIVA                  AS Activa,
    FECHA_ALTA              AS FechaAlta,
    USUARIO_ALTA            AS UsuarioAlta
FROM GR_EMISORA
WHERE ACTIVA = 1
ORDER BY NOMBRE;";


    public const string ObtenerPorId = @"
SELECT
    ID_EMISORA              AS EmisoraId,
    SIGLAS                  AS Siglas,
    NOMBRE                  AS Nombre,
    DINESAT_STATION_ID      AS DinesatStationId,
    ACTIVA                  AS Activa,
    FECHA_ALTA              AS FechaAlta,
    USUARIO_ALTA            AS UsuarioAlta
FROM GR_EMISORA
WHERE ID_EMISORA = @Id;";
}