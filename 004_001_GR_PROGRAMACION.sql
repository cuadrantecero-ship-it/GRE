USE GestionRadioERP;
GO

/******************************************************************************
    TABLA: GR_PROGRAMACION
    Cabecera de la programación diaria.
******************************************************************************/

IF OBJECT_ID('dbo.GR_PROGRAMACION','U') IS NOT NULL
BEGIN
    DROP TABLE dbo.GR_PROGRAMACION;
END
GO

CREATE TABLE dbo.GR_PROGRAMACION
(
    --------------------------------------------------------------------------
    -- PRIMARY KEY
    --------------------------------------------------------------------------

    ID_PROGRAMACION             BIGINT IDENTITY(1,1) NOT NULL,

    --------------------------------------------------------------------------
    -- RELACIONES
    --------------------------------------------------------------------------

    ID_EMISORA                  BIGINT NOT NULL,

    ID_PARRILLA                 BIGINT NOT NULL,

    --------------------------------------------------------------------------
    -- PROGRAMACIÓN
    --------------------------------------------------------------------------

    FECHA                       DATE NOT NULL,

    --------------------------------------------------------------------------
    -- DINESAT
    --------------------------------------------------------------------------

    PROGRAMMING_ID_DINESAT      BIGINT NULL,

    --------------------------------------------------------------------------
    -- ESTADO
    --------------------------------------------------------------------------

    ESTADO                      TINYINT NOT NULL
        CONSTRAINT DF_GR_PROGRAMACION_ESTADO
        DEFAULT (1),

    ACTIVA                      BIT NOT NULL
        CONSTRAINT DF_GR_PROGRAMACION_ACTIVA
        DEFAULT (1),

    --------------------------------------------------------------------------
    -- AUDITORÍA
    --------------------------------------------------------------------------

    FECHA_CREACION              DATETIME2 NOT NULL
        CONSTRAINT DF_GR_PROGRAMACION_FECHA_CREACION
        DEFAULT(SYSDATETIME()),

    USUARIO_CREACION            NVARCHAR(100) NOT NULL,

    FECHA_MODIFICACION          DATETIME2 NULL,

    USUARIO_MODIFICACION        NVARCHAR(100) NULL,

    --------------------------------------------------------------------------
    -- PRIMARY KEY
    --------------------------------------------------------------------------

    CONSTRAINT PK_GR_PROGRAMACION
        PRIMARY KEY CLUSTERED
        (
            ID_PROGRAMACION
        )
);
GO

/******************************************************************************
    ÍNDICES
******************************************************************************/

CREATE INDEX IX_GR_PROGRAMACION_FECHA
ON dbo.GR_PROGRAMACION
(
    FECHA
);
GO

CREATE INDEX IX_GR_PROGRAMACION_EMISORA
ON dbo.GR_PROGRAMACION
(
    ID_EMISORA
);
GO

CREATE INDEX IX_GR_PROGRAMACION_PARRILLA
ON dbo.GR_PROGRAMACION
(
    ID_PARRILLA
);
GO

CREATE INDEX IX_GR_PROGRAMACION_DINESAT
ON dbo.GR_PROGRAMACION
(
    PROGRAMMING_ID_DINESAT
);
GO

/******************************************************************************
    ÍNDICE PRINCIPAL DE CONSULTA
******************************************************************************/

CREATE INDEX IX_GR_PROGRAMACION_EMISORA_FECHA_ACTIVA
ON dbo.GR_PROGRAMACION
(
    ID_EMISORA,
    FECHA,
    ACTIVA
);
GO

/******************************************************************************
    UNA PROGRAMACIÓN POR EMISORA Y FECHA
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
ADD CONSTRAINT FK_GR_PROGRAMACION_EMISORA
FOREIGN KEY (ID_EMISORA)
REFERENCES dbo.GR_EMISORA(ID_EMISORA)
ON UPDATE NO ACTION
ON DELETE NO ACTION;
GO

ALTER TABLE dbo.GR_PROGRAMACION
ADD CONSTRAINT FK_GR_PROGRAMACION_PARRILLA
FOREIGN KEY (ID_PARRILLA)
REFERENCES dbo.GR_PARRILLA(ID_PARRILLA)
ON UPDATE NO ACTION
ON DELETE NO ACTION;
GO