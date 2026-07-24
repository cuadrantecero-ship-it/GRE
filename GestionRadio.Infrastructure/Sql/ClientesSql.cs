namespace GestionRadio.Infrastructure.Sql;

public static class ClientesSql
{
    //=========================================================
    // LISTADO GENERAL
    //=========================================================

    public const string ObtenerTodos = @"
SELECT
    ID_CLIENTE              AS IdCliente,
    FOLIO                   AS Folio,
    RAZON_SOCIAL            AS RazonSocial,
    NOMBRE_COMERCIAL        AS NombreComercial,
    RFC                     AS RFC,
    REGIMEN_FISCAL          AS RegimenFiscal,
    USO_CFDI                AS UsoCFDI,
    CONTACTO                AS Contacto,
    TELEFONO                AS Telefono,
    WHATSAPP                AS WhatsApp,
    EMAIL                   AS Email,
    CALLE                   AS Calle,
    NUMERO_EXTERIOR         AS NumeroExterior,
    NUMERO_INTERIOR         AS NumeroInterior,
    COLONIA                 AS Colonia,
    CIUDAD                  AS Ciudad,
    ESTADO                  AS Estado,
    CODIGO_POSTAL           AS CodigoPostal,
    LIMITE_CREDITO          AS LimiteCredito,
    DIAS_CREDITO            AS DiasCredito,
    ACTIVO                  AS Activo,
    FECHA_ALTA              AS FechaAlta,
    USUARIO_ALTA            AS UsuarioAlta,
    FECHA_MODIFICACION      AS FechaModificacion,
    USUARIO_MODIFICACION    AS UsuarioModificacion
FROM GR_CLIENTE
ORDER BY RAZON_SOCIAL;";

    //=========================================================
    // CLIENTE POR ID
    //=========================================================

    public const string ObtenerPorId = @"
SELECT
    ID_CLIENTE              AS IdCliente,
    FOLIO                   AS Folio,
    RAZON_SOCIAL            AS RazonSocial,
    NOMBRE_COMERCIAL        AS NombreComercial,
    RFC                     AS RFC,
    REGIMEN_FISCAL          AS RegimenFiscal,
    USO_CFDI                AS UsoCFDI,
    CONTACTO                AS Contacto,
    TELEFONO                AS Telefono,
    WHATSAPP                AS WhatsApp,
    EMAIL                   AS Email,
    CALLE                   AS Calle,
    NUMERO_EXTERIOR         AS NumeroExterior,
    NUMERO_INTERIOR         AS NumeroInterior,
    COLONIA                 AS Colonia,
    CIUDAD                  AS Ciudad,
    ESTADO                  AS Estado,
    CODIGO_POSTAL           AS CodigoPostal,
    LIMITE_CREDITO          AS LimiteCredito,
    DIAS_CREDITO            AS DiasCredito,
    ACTIVO                  AS Activo,
    FECHA_ALTA              AS FechaAlta,
    USUARIO_ALTA            AS UsuarioAlta,
    FECHA_MODIFICACION      AS FechaModificacion,
    USUARIO_MODIFICACION    AS UsuarioModificacion
FROM GR_CLIENTE
WHERE ID_CLIENTE = @IdCliente;";

    //=========================================================
    // CLIENTE POR FOLIO
    //=========================================================

    public const string ObtenerPorFolio = @"
SELECT
    ID_CLIENTE              AS IdCliente,
    FOLIO                   AS Folio,
    RAZON_SOCIAL            AS RazonSocial,
    NOMBRE_COMERCIAL        AS NombreComercial,
    RFC                     AS RFC,
    REGIMEN_FISCAL          AS RegimenFiscal,
    USO_CFDI                AS UsoCFDI,
    CONTACTO                AS Contacto,
    TELEFONO                AS Telefono,
    WHATSAPP                AS WhatsApp,
    EMAIL                   AS Email,
    CALLE                   AS Calle,
    NUMERO_EXTERIOR         AS NumeroExterior,
    NUMERO_INTERIOR         AS NumeroInterior,
    COLONIA                 AS Colonia,
    CIUDAD                  AS Ciudad,
    ESTADO                  AS Estado,
    CODIGO_POSTAL           AS CodigoPostal,
    LIMITE_CREDITO          AS LimiteCredito,
    DIAS_CREDITO            AS DiasCredito,
    ACTIVO                  AS Activo,
    FECHA_ALTA              AS FechaAlta,
    USUARIO_ALTA            AS UsuarioAlta,
    FECHA_MODIFICACION      AS FechaModificacion,
    USUARIO_MODIFICACION    AS UsuarioModificacion
FROM GR_CLIENTE
WHERE FOLIO = @Folio;";

    //=========================================================
    // VALIDAR FOLIO
    //=========================================================

    public const string ExisteFolio = @"
SELECT COUNT(*)
FROM GR_CLIENTE
WHERE FOLIO = @Folio;";

    //=========================================================
    // BUSCADOR
    //=========================================================

    public const string Buscar = @"
SELECT
    ID_CLIENTE              AS IdCliente,
    FOLIO                   AS Folio,
    RAZON_SOCIAL            AS RazonSocial,
    CONTACTO                AS Contacto,
    TELEFONO                AS Telefono,
    EMAIL                   AS Email,
    ACTIVO                  AS Activo
FROM GR_CLIENTE
WHERE
      FOLIO LIKE '%' + @Texto + '%'
   OR RAZON_SOCIAL LIKE '%' + @Texto + '%'
   OR CONTACTO LIKE '%' + @Texto + '%'
   OR RFC LIKE '%' + @Texto + '%'
ORDER BY RAZON_SOCIAL;";

    //=========================================================
    // SOLO ACTIVOS
    //=========================================================

    public const string ObtenerActivos = @"
SELECT *
FROM GR_CLIENTE
WHERE ACTIVO = 1
ORDER BY RAZON_SOCIAL;";

    //=========================================================
    // SOLO INACTIVOS
    //=========================================================

    public const string ObtenerInactivos = @"
SELECT *
FROM GR_CLIENTE
WHERE ACTIVO = 0
ORDER BY RAZON_SOCIAL;";

    //=========================================================
    // INSERTAR
    //=========================================================

    public const string Insertar = @"
INSERT INTO GR_CLIENTE
(
    FOLIO,
    RAZON_SOCIAL,
    NOMBRE_COMERCIAL,
    RFC,
    REGIMEN_FISCAL,
    USO_CFDI,
    CONTACTO,
    TELEFONO,
    WHATSAPP,
    EMAIL,
    CALLE,
    NUMERO_EXTERIOR,
    NUMERO_INTERIOR,
    COLONIA,
    CIUDAD,
    ESTADO,
    CODIGO_POSTAL,
    LIMITE_CREDITO,
    DIAS_CREDITO,
    ACTIVO,
    FECHA_ALTA,
    USUARIO_ALTA
)
VALUES
(
    @Folio,
    @RazonSocial,
    @NombreComercial,
    @RFC,
    @RegimenFiscal,
    @UsoCFDI,
    @Contacto,
    @Telefono,
    @WhatsApp,
    @Email,
    @Calle,
    @NumeroExterior,
    @NumeroInterior,
    @Colonia,
    @Ciudad,
    @Estado,
    @CodigoPostal,
    @LimiteCredito,
    @DiasCredito,
    @Activo,
    @FechaAlta,
    @UsuarioAlta
);

SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";

    //=========================================================
    // ACTUALIZAR
    //=========================================================

    public const string Actualizar = @"
UPDATE GR_CLIENTE
SET
    RAZON_SOCIAL         = @RazonSocial,
    NOMBRE_COMERCIAL     = @NombreComercial,
    RFC                  = @RFC,
    REGIMEN_FISCAL       = @RegimenFiscal,
    USO_CFDI             = @UsoCFDI,
    CONTACTO             = @Contacto,
    TELEFONO             = @Telefono,
    WHATSAPP             = @WhatsApp,
    EMAIL                = @Email,
    CALLE                = @Calle,
    NUMERO_EXTERIOR      = @NumeroExterior,
    NUMERO_INTERIOR      = @NumeroInterior,
    COLONIA              = @Colonia,
    CIUDAD               = @Ciudad,
    ESTADO               = @Estado,
    CODIGO_POSTAL        = @CodigoPostal,
    LIMITE_CREDITO       = @LimiteCredito,
    DIAS_CREDITO         = @DiasCredito,
    FECHA_MODIFICACION   = @FechaModificacion,
    USUARIO_MODIFICACION = @UsuarioModificacion
WHERE ID_CLIENTE = @IdCliente;";

    //=========================================================
    // CAMBIAR ESTADO
    //=========================================================

    public const string CambiarEstado = @"
UPDATE GR_CLIENTE
SET
    ACTIVO                = @Activo,
    FECHA_MODIFICACION    = @FechaModificacion,
    USUARIO_MODIFICACION  = @UsuarioModificacion
WHERE ID_CLIENTE = @IdCliente;";
}