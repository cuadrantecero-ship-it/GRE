USE GestionRadioERP;
GO

/******************************************************************************
    TABLA: GR_PROGRAMACION
    Cabecera de la programación diaria por emisora.
******************************************************************************/

IF OBJECT_ID('dbo.GR_PROGRAMACION', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.GR_PROGRAMACION;
END
GO

CREATE TABLE dbo.GR_PROGRAMACION
(
    --------------------------------------------------------------------------
    -- PRIMARY KEY
    --------------------------------------------------------------------------

    ID_PROGRAMACION         BIGINT IDENTITY(1,1) NOT NULL,

    --------------------------------------------------------------------------
    -- DATOS GENERALES
    --------------------------------------------------------------------------

    ID_EMISORA              BIGINT NOT NULL,

    ID_PARRILLA             BIGINT NOT NULL,

    FECHA                   DATE NOT NULL,

    --------------------------------------------------------------------------
    -- DINESAT
    --------------------------------------------------------------------------

    PROGRAMMING_ID_DINESAT  BIGINT NULL,

    --------------------------------------------------------------------------
    -- ESTADO
    --------------------------------------------------------------------------

    ESTADO                  NVARCHAR(30) NOT NULL
        CONSTRAINT DF_GR_PROGRAMACION_ESTADO
        DEFAULT ('BORRADOR'),

    ACTIVA                  BIT NOT NULL
        CONSTRAINT DF_GR_PROGRAMACION_ACTIVA
        DEFAULT (1),

    --------------------------------------------------------------------------
    -- AUDITORIA
    --------------------------------------------------------------------------

    FECHA_CREACION          DATETIME2 NOT NULL
        CONSTRAINT DF_GR_PROGRAMACION_FECHA_CREACION
        DEFAULT (SYSDATETIME()),

    USUARIO_CREACION        NVARCHAR(100) NOT NULL,

    FECHA_MODIFICACION      DATETIME2 NULL,

    USUARIO_MODIFICACION    NVARCHAR(100) NULL,

    --------------------------------------------------------------------------
    -- CONSTRAINTS
    --------------------------------------------------------------------------

    CONSTRAINT PK_GR_PROGRAMACION
        PRIMARY KEY (ID_PROGRAMACION)
);
GO

/******************************************************************************
    INDICES
******************************************************************************/

CREATE INDEX IX_GR_PROGRAMACION_FECHA
ON dbo.GR_PROGRAMACION(FECHA);
GO

CREATE INDEX IX_GR_PROGRAMACION_EMISORA
ON dbo.GR_PROGRAMACION(ID_EMISORA);
GO

CREATE INDEX IX_GR_PROGRAMACION_PARRILLA
ON dbo.GR_PROGRAMACION(ID_PARRILLA);
GO

CREATE INDEX IX_GR_PROGRAMACION_DINESAT
ON dbo.GR_PROGRAMACION(PROGRAMMING_ID_DINESAT);
GO

/******************************************************************************
    UNA PROGRAMACION POR EMISORA Y FECHA
******************************************************************************/

CREATE UNIQUE INDEX UX_GR_PROGRAMACION_EMISORA_FECHA
ON dbo.GR_PROGRAMACION
(
    ID_EMISORA,
    FECHA
);
GO

/******************************************************************************
    FOREIGN KEYS
******************************************************************************/

ALTER TABLE dbo.GR_PROGRAMACION
ADD CONSTRAINT FK_GR_PROGRAMACION_PARRILLA
FOREIGN KEY (ID_PARRILLA)
REFERENCES dbo.GR_PARRILLA(ID_PARRILLA);
GO