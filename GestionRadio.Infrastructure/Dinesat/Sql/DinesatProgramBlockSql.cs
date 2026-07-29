namespace GestionRadio.Infrastructure.Sql;

public static class DinesatProgramBlockSql
{
    public const string ObtenerPorProgramacion = @"
SELECT
    PGMBLOCKID AS ProgramBlockId,
    PGMID AS ProgrammingId,
    BLOCKTIME AS HoraInicio,
    DESCRIPTION AS Nombre
FROM PROGRAMBLOCK
WHERE PGMID = @ProgrammingId
ORDER BY BLOCKTIME;";

    public const string ObtenerPorId = @"
SELECT
    PGMBLOCKID AS ProgramBlockId,
    PGMID AS ProgrammingId,
    BLOCKTIME AS HoraInicio,
    DESCRIPTION AS Nombre
FROM PROGRAMBLOCK
WHERE PGMBLOCKID = @ProgramBlockId;";

    public const string ObtenerPorHora = @"
SELECT TOP (1)
    PGMBLOCKID AS ProgramBlockId,
    PGMID AS ProgrammingId,
    BLOCKTIME AS HoraInicio,
    DESCRIPTION AS Nombre
FROM PROGRAMBLOCK
WHERE
    PGMID = @ProgrammingId
    AND BLOCKTIME = @Hora;";
}