namespace GestionRadio.Infrastructure.Sql;

public static class DinesatPublishSql
{
    //==========================================================
    // PROGRAMMING
    //==========================================================

    public const string ExisteProgramming = @"
SELECT PGMID
FROM PROGRAMMING
WHERE STATIONID = @StationId
  AND PGMDATE = @ProgramDate;";

    public const string CrearProgramming = @"
INSERT INTO PROGRAMMING
(
    STATIONID,
    PGMDATE,
    PGMTYPE,
    PGMACTIVE,
    UTCMODIFIEDDATE,
    UTCMODIFIEDTIME
)
VALUES
(
    @StationId,
    @ProgramDate,
    1,
    1,
    @UtcDate,
    @UtcTime
);

SELECT CAST(SCOPE_IDENTITY() AS INT);
";

    //==========================================================
    // PROGRAMBLOCK
    //==========================================================

    public const string CrearProgramBlock = @"
INSERT INTO PROGRAMBLOCK
(
    PGMID,
    DESCRIPTION,
    BLOCKTIME
)
VALUES
(
    @PgmId,
    @Description,
    @BlockTime
);

SELECT CAST(SCOPE_IDENTITY() AS INT);
";

    //==========================================================
    // MATERIAL
    //==========================================================

    public const string ObtenerMaterialId = @"
SELECT MATERIALID
FROM MATERIAL
WHERE CODE = @Code;
";

    //==========================================================
    // EVENTO 0
    //==========================================================

    public const string CrearEventoInicio = @"
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
    @BlockId,
    0,
    -1,
    0,
    NULL,
    0,
    NULL,
    0
);
";

    //==========================================================
    // EVENTO COMERCIAL
    //==========================================================

    public const string CrearEventoMaterial = @"
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
    @BlockId,
    1,
    @MaterialId,
    0,
    @TrafficCode,
    0,
    NULL,
    0
);
";
}