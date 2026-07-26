namespace GestionRadio.Infrastructure.Sql;

public static class DinesatProgramEventSql
{
    public const string ObtenerPorBloque = @"
SELECT
    PGMEVENTID AS ProgramEventId,
    PGMBLOCKID AS ProgramBlockId,
    ITEMORDER AS ItemOrder,
    MATERIALID AS MaterialId,
    CONDITION AS Condition,
    TRAFFICCODE AS TrafficCode,
    TRAFFICINDEX AS TrafficIndex,
    LIVEDESC AS LiveDescription,
    LIVELENGTH AS LiveLength
FROM PROGRAMEVENT
WHERE PGMBLOCKID = @ProgramBlockId
ORDER BY ITEMORDER;";


    public const string ObtenerPorId = @"
SELECT
    PGMEVENTID AS ProgramEventId,
    PGMBLOCKID AS ProgramBlockId,
    ITEMORDER AS ItemOrder,
    MATERIALID AS MaterialId,
    CONDITION AS Condition,
    TRAFFICCODE AS TrafficCode,
    TRAFFICINDEX AS TrafficIndex,
    LIVEDESC AS LiveDescription,
    LIVELENGTH AS LiveLength
FROM PROGRAMEVENT
WHERE PGMEVENTID = @Id;";


    public const string ObtenerSiguienteItemOrder = @"
SELECT
    ISNULL(MAX(ITEMORDER), 0) + 1
FROM PROGRAMEVENT
WHERE PGMBLOCKID = @ProgramBlockId;";


    public const string Insertar = @"
INSERT INTO PROGRAMEVENT
(
    PGMBLOCKID,
    ITEMORDER,
    MATERIALID,
    CONDITION,
    TRAFFICCODE,
    TRAFFICINDEX,
    LIVEDESC,
    LIVELENGTH
)
VALUES
(
    @ProgramBlockId,
    @ItemOrder,
    @MaterialId,
    @Condition,
    @TrafficCode,
    @TrafficIndex,
    @LiveDescription,
    @LiveLength
);

SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";
}