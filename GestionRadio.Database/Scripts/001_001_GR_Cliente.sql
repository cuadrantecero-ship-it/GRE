/******************************************************************************
 PROYECTO : GESTIÓN RADIO ERP
 ARCHIVO  : 001_002_GR_Cliente.sql
 VERSION  : 1.0.0
 MODULO   : CLIENTES
 PARTE    : 1 DE N

 DESCRIPCIÓN
 ------------------------------------------------------------------------------
 Creación de la tabla principal GR_CLIENTE.
******************************************************************************/

SET NOCOUNT ON;
GO

IF OBJECT_ID('dbo.GR_CLIENTE','U') IS NOT NULL
BEGIN
    DROP TABLE dbo.GR_CLIENTE;
END;
GO

CREATE TABLE dbo.GR_CLIENTE
(
    --------------------------------------------------------------------------
    -- LLAVE PRIMARIA
    --------------------------------------------------------------------------

    IdCliente BIGINT IDENTITY(1,1) NOT NULL,

    --------------------------------------------------------------------------
    -- IDENTIFICACIÓN
    --------------------------------------------------------------------------

    CodigoCliente VARCHAR(20) NOT NULL,

    DinesatCompanyId INT NULL,

    --------------------------------------------------------------------------
    -- CATÁLOGOS
    --------------------------------------------------------------------------

    TipoClienteId SMALLINT NOT NULL,

    EstadoClienteId SMALLINT NOT NULL,

    --------------------------------------------------------------------------
    -- DATOS FISCALES
    --------------------------------------------------------------------------

    RFC VARCHAR(13) NOT NULL,

    RazonSocial NVARCHAR(250) NOT NULL,

    NombreComercial NVARCHAR(250) NOT NULL,

    RepresentanteLegal NVARCHAR(200) NULL,

    RegimenFiscal NVARCHAR(120) NULL,

    UsoCFDI NVARCHAR(120) NULL,

    --------------------------------------------------------------------------
    -- DATOS COMERCIALES
    --------------------------------------------------------------------------

    Moneda CHAR(3) NOT NULL
        CONSTRAINT DF_GR_CLIENTE_MONEDA
        DEFAULT('MXN'),

    CondicionPago NVARCHAR(100) NULL,

    LimiteCredito DECIMAL(18,2) NOT NULL
        CONSTRAINT DF_GR_CLIENTE_LIMITE
        DEFAULT(0),

    DiasCredito SMALLINT NOT NULL
        CONSTRAINT DF_GR_CLIENTE_DIAS
        DEFAULT(0),

    EjecutivoVentas NVARCHAR(150) NULL,

    --------------------------------------------------------------------------
    -- INFORMACIÓN GENERAL
    --------------------------------------------------------------------------

    SitioWeb NVARCHAR(250) NULL,

    Observaciones NVARCHAR(MAX) NULL,

    --------------------------------------------------------------------------
    -- ESTADO
    --------------------------------------------------------------------------

    Activo BIT NOT NULL
        CONSTRAINT DF_GR_CLIENTE_ACTIVO
        DEFAULT(1),

    --------------------------------------------------------------------------
    -- AUDITORÍA
    --------------------------------------------------------------------------

    FechaCreacion DATETIME2(0) NOT NULL
        CONSTRAINT DF_GR_CLIENTE_FECHA_CREACION
        DEFAULT(SYSDATETIME()),

    UsuarioCreacion NVARCHAR(100) NOT NULL,

    FechaModificacion DATETIME2(0) NULL,

    UsuarioModificacion NVARCHAR(100) NULL,

    RowVersion ROWVERSION,

    --------------------------------------------------------------------------
    -- CONSTRAINTS
    --------------------------------------------------------------------------

    CONSTRAINT PK_GR_CLIENTE
        PRIMARY KEY CLUSTERED
        (
            IdCliente
        ),

    CONSTRAINT UQ_GR_CLIENTE_CODIGO
        UNIQUE
        (
            CodigoCliente
        ),

    CONSTRAINT UQ_GR_CLIENTE_RFC
        UNIQUE
        (
            RFC
        ),

    CONSTRAINT FK_GR_CLIENTE_TIPO
        FOREIGN KEY
        (
            TipoClienteId
        )
        REFERENCES dbo.GR_CAT_TIPO_CLIENTE
        (
            TipoClienteId
        ),

    CONSTRAINT FK_GR_CLIENTE_ESTADO
        FOREIGN KEY
        (
            EstadoClienteId
        )
        REFERENCES dbo.GR_CAT_ESTADO_CLIENTE
        (
            EstadoClienteId
        ),

    CONSTRAINT CK_GR_CLIENTE_DIAS_CREDITO
        CHECK
        (
            DiasCredito >= 0
        ),

    CONSTRAINT CK_GR_CLIENTE_LIMITE_CREDITO
        CHECK
        (
            LimiteCredito >= 0
        ),

    CONSTRAINT CK_GR_CLIENTE_MONEDA
        CHECK
        (
            Moneda IN ('MXN','USD','EUR')
        )
);

------------------------------------------------------------------------------
-- ÍNDICES
------------------------------------------------------------------------------

CREATE INDEX IX_GR_CLIENTE_RAZON_SOCIAL
ON dbo.GR_CLIENTE(RazonSocial);
GO

CREATE INDEX IX_GR_CLIENTE_NOMBRE_COMERCIAL
ON dbo.GR_CLIENTE(NombreComercial);
GO

CREATE INDEX IX_GR_CLIENTE_ESTADO
ON dbo.GR_CLIENTE(EstadoClienteId);
GO

CREATE INDEX IX_GR_CLIENTE_TIPO
ON dbo.GR_CLIENTE(TipoClienteId);
GO

CREATE INDEX IX_GR_CLIENTE_ACTIVO
ON dbo.GR_CLIENTE(Activo);
GO

CREATE INDEX IX_GR_CLIENTE_EJECUTIVO
ON dbo.GR_CLIENTE(EjecutivoVentas);
GO

CREATE INDEX IX_GR_CLIENTE_DINESAT
ON dbo.GR_CLIENTE(DinesatCompanyId);
GO

------------------------------------------------------------------------------
-- DESCRIPCIONES (EXTENDED PROPERTIES)
------------------------------------------------------------------------------

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Tabla principal de clientes del ERP Gestión Radio.',
    @level0type=N'SCHEMA', @level0name='dbo',
    @level1type=N'TABLE',  @level1name='GR_CLIENTE';
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Código interno único del cliente.',
    @level0type=N'SCHEMA', @level0name='dbo',
    @level1type=N'TABLE',  @level1name='GR_CLIENTE',
    @level2type=N'COLUMN', @level2name='CodigoCliente';
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Identificador del cliente en Dinesat para sincronización.',
    @level0type=N'SCHEMA', @level0name='dbo',
    @level1type=N'TABLE',  @level1name='GR_CLIENTE',
    @level2type=N'COLUMN', @level2name='DinesatCompanyId';
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'RFC del cliente.',
    @level0type=N'SCHEMA', @level0name='dbo',
    @level1type=N'TABLE',  @level1name='GR_CLIENTE',
    @level2type=N'COLUMN', @level2name='RFC';
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Razón Social registrada ante el SAT.',
    @level0type=N'SCHEMA', @level0name='dbo',
    @level1type=N'TABLE',  @level1name='GR_CLIENTE',
    @level2type=N'COLUMN', @level2name='RazonSocial';
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Nombre comercial del cliente.',
    @level0type=N'SCHEMA', @level0name='dbo',
    @level1type=N'TABLE',  @level1name='GR_CLIENTE',
    @level2type=N'COLUMN', @level2name='NombreComercial';
GO

PRINT '==========================================================';
PRINT 'TABLA GR_CLIENTE CREADA CORRECTAMENTE';
PRINT '==========================================================';
GO

SET NOCOUNT ON;
GO

IF OBJECT_ID('dbo.GR_CONTACTO','U') IS NOT NULL
BEGIN
    DROP TABLE dbo.GR_CONTACTO;
END;
GO

CREATE TABLE dbo.GR_CONTACTO
(
    --------------------------------------------------------------------------
    -- LLAVE PRIMARIA
    --------------------------------------------------------------------------

    IdContacto BIGINT IDENTITY(1,1) NOT NULL,

    IdCliente BIGINT NOT NULL,

    --------------------------------------------------------------------------
    -- DATOS PERSONALES
    --------------------------------------------------------------------------

    Nombre NVARCHAR(150) NOT NULL,

    ApellidoPaterno NVARCHAR(100) NULL,

    ApellidoMaterno NVARCHAR(100) NULL,

    Cargo NVARCHAR(120) NULL,

    Departamento NVARCHAR(120) NULL,

    --------------------------------------------------------------------------
    -- CONTACTO
    --------------------------------------------------------------------------

    Telefono NVARCHAR(30) NULL,

    TelefonoMovil NVARCHAR(30) NULL,

    Extension NVARCHAR(10) NULL,

    CorreoElectronico NVARCHAR(200) NULL,

    SitioWeb NVARCHAR(250) NULL,

    --------------------------------------------------------------------------
    -- PREFERENCIAS
    --------------------------------------------------------------------------

    EsContactoPrincipal BIT NOT NULL
        CONSTRAINT DF_GR_CONTACTO_PRINCIPAL
        DEFAULT(0),

    RecibeFacturas BIT NOT NULL
        CONSTRAINT DF_GR_CONTACTO_FACTURAS
        DEFAULT(1),

    RecibeProgramacion BIT NOT NULL
        CONSTRAINT DF_GR_CONTACTO_PROGRAMACION
        DEFAULT(1),

    --------------------------------------------------------------------------
    -- OBSERVACIONES
    --------------------------------------------------------------------------

    Observaciones NVARCHAR(MAX) NULL,

    --------------------------------------------------------------------------
    -- ESTADO
    --------------------------------------------------------------------------

    Activo BIT NOT NULL
        CONSTRAINT DF_GR_CONTACTO_ACTIVO
        DEFAULT(1),

    --------------------------------------------------------------------------
    -- AUDITORÍA
    --------------------------------------------------------------------------

    FechaCreacion DATETIME2(0) NOT NULL
        CONSTRAINT DF_GR_CONTACTO_FECHA_CREACION
        DEFAULT(SYSDATETIME()),

    UsuarioCreacion NVARCHAR(100) NOT NULL,

    FechaModificacion DATETIME2(0) NULL,

    UsuarioModificacion NVARCHAR(100) NULL,

    RowVersion ROWVERSION,

    --------------------------------------------------------------------------
    -- CONSTRAINTS
    --------------------------------------------------------------------------

    CONSTRAINT PK_GR_CONTACTO
        PRIMARY KEY CLUSTERED
        (
            IdContacto
        ),

    CONSTRAINT FK_GR_CONTACTO_CLIENTE
        FOREIGN KEY
        (
            IdCliente
        )
        REFERENCES dbo.GR_CLIENTE
        (
            IdCliente
        )
        ON DELETE CASCADE
);
GO

/******************************************************************************
 ÍNDICES
******************************************************************************/

CREATE INDEX IX_GR_CONTACTO_CLIENTE
ON dbo.GR_CONTACTO(IdCliente);
GO

CREATE INDEX IX_GR_CONTACTO_NOMBRE
ON dbo.GR_CONTACTO(Nombre);
GO

CREATE INDEX IX_GR_CONTACTO_CORREO
ON dbo.GR_CONTACTO(CorreoElectronico);
GO

CREATE INDEX IX_GR_CONTACTO_PRINCIPAL
ON dbo.GR_CONTACTO(EsContactoPrincipal);
GO

/******************************************************************************
 DESCRIPCIÓN
******************************************************************************/

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Contactos asociados a los clientes.',
    @level0type=N'SCHEMA', @level0name='dbo',
    @level1type=N'TABLE', @level1name='GR_CONTACTO';
GO

PRINT '==========================================================';
PRINT 'TABLA GR_CONTACTO CREADA CORRECTAMENTE';
PRINT '==========================================================';
GO

SET NOCOUNT ON;
GO

/******************************************************************************
GR_CLIENTE
******************************************************************************/

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_GR_CLIENTE_RFC_RAZON')
BEGIN
    CREATE NONCLUSTERED INDEX IX_GR_CLIENTE_RFC_RAZON
    ON dbo.GR_CLIENTE
    (
        RFC,
        RazonSocial
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_GR_CLIENTE_ESTADO_ACTIVO')
BEGIN
    CREATE NONCLUSTERED INDEX IX_GR_CLIENTE_ESTADO_ACTIVO
    ON dbo.GR_CLIENTE
    (
        EstadoClienteId,
        Activo
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_GR_CLIENTE_TIPO_ESTADO')
BEGIN
    CREATE NONCLUSTERED INDEX IX_GR_CLIENTE_TIPO_ESTADO
    ON dbo.GR_CLIENTE
    (
        TipoClienteId,
        EstadoClienteId
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_GR_CLIENTE_DINESAT')
BEGIN
    CREATE NONCLUSTERED INDEX IX_GR_CLIENTE_DINESAT
    ON dbo.GR_CLIENTE
    (
        DinesatCompanyId
    );
END;
GO

/******************************************************************************
GR_CONTACTO
******************************************************************************/

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_GR_CONTACTO_CLIENTE_PRINCIPAL')
BEGIN
    CREATE NONCLUSTERED INDEX IX_GR_CONTACTO_CLIENTE_PRINCIPAL
    ON dbo.GR_CONTACTO
    (
        IdCliente,
        EsContactoPrincipal
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_GR_CONTACTO_CLIENTE_ACTIVO')
BEGIN
    CREATE NONCLUSTERED INDEX IX_GR_CONTACTO_CLIENTE_ACTIVO
    ON dbo.GR_CONTACTO
    (
        IdCliente,
        Activo
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_GR_CONTACTO_CORREO')
BEGIN
    CREATE NONCLUSTERED INDEX IX_GR_CONTACTO_CORREO
    ON dbo.GR_CONTACTO
    (
        CorreoElectronico
    );
END;
GO

/******************************************************************************
ESTADÍSTICAS
******************************************************************************/

UPDATE STATISTICS dbo.GR_CLIENTE;
GO

UPDATE STATISTICS dbo.GR_CONTACTO;
GO

/******************************************************************************
FINAL
******************************************************************************/

PRINT '==============================================================';
PRINT 'INDICES DEL MODULO CLIENTES CREADOS CORRECTAMENTE';
PRINT '==============================================================';
GO

SET NOCOUNT ON;
GO

/******************************************************************************
 CLIENTE GENÉRICO DEL SISTEMA
******************************************************************************/

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.GR_CLIENTE
    WHERE CodigoCliente='CLI000001'
)
BEGIN

INSERT INTO dbo.GR_CLIENTE
(
    CodigoCliente,
    DinesatCompanyId,
    TipoClienteId,
    EstadoClienteId,
    RFC,
    RazonSocial,
    NombreComercial,
    RepresentanteLegal,
    RegimenFiscal,
    UsoCFDI,
    Moneda,
    CondicionPago,
    LimiteCredito,
    DiasCredito,
    EjecutivoVentas,
    SitioWeb,
    Observaciones,
    Activo,
    UsuarioCreacion
)
VALUES
(
    'CLI000001',
    NULL,
    1,
    2,
    'XAXX010101000',
    'CLIENTE DEMOSTRACION',
    'CLIENTE DEMOSTRACION',
    NULL,
    '601',
    'G03',
    'MXN',
    'CONTADO',
    0,
    0,
    'SISTEMA',
    NULL,
    'REGISTRO CREADO AUTOMATICAMENTE',
    1,
    'SYSTEM'
);

END;
GO

/******************************************************************************
 CONTACTO PRINCIPAL
******************************************************************************/

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.GR_CONTACTO
    WHERE CorreoElectronico='demo@gestionradio.local'
)
BEGIN

INSERT INTO dbo.GR_CONTACTO
(
    IdCliente,
    Nombre,
    Cargo,
    Telefono,
    CorreoElectronico,
    EsContactoPrincipal,
    RecibeFacturas,
    RecibeProgramacion,
    Activo,
    UsuarioCreacion
)
SELECT

    IdCliente,
    'CONTACTO PRINCIPAL',
    'ADMINISTRADOR',
    '',
    'demo@gestionradio.local',
    1,
    1,
    1,
    1,
    'SYSTEM'

FROM dbo.GR_CLIENTE
WHERE CodigoCliente='CLI000001';

END;
GO

/******************************************************************************
 VALIDACIÓN
******************************************************************************/

PRINT '';
PRINT '==============================================';
PRINT 'MÓDULO CLIENTES INSTALADO CORRECTAMENTE';
PRINT '==============================================';

PRINT '';

PRINT 'TABLAS INSTALADAS';

PRINT 'GR_CAT_TIPO_CLIENTE';
PRINT 'GR_CAT_ESTADO_CLIENTE';
PRINT 'GR_CLIENTE';
PRINT 'GR_CONTACTO';

PRINT '';

PRINT 'CLIENTE DEMO CREADO';

PRINT '';

SELECT
    CodigoCliente,
    NombreComercial,
    RFC,
    Activo
FROM dbo.GR_CLIENTE;

GO