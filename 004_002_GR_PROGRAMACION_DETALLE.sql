USE GestionRadioERP;
GO

/******************************************************************************
    TABLA: GR_PROGRAMACION_DETALLE
    Eventos individuales de una programación.
******************************************************************************/

IF OBJECT_ID('dbo.GR_PROGRAMACION_DETALLE', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.GR_PROGRAMACION_DETALLE;
END
GO

CREATE TABLE dbo.GR_PROGRAMACION_DETALLE
(
    --------------------------------------------------------------------------
    -- PRIMARY KEY
    --------------------------------------------------------------------------

    ID_PROGRAMACION_DETALLE      BIGINT IDENTITY(1,1) NOT NULL,

    --------------------------------------------------------------------------
    -- RELACIÓN
    --------------------------------------------------------------------------

    ID_PROGRAMACION              BIGINT NOT NULL,

    ID_BLOQUE                    BIGINT NOT NULL,

    ID_CLIENTE                   BIGINT NOT NULL,

    ID_CAMPANIA                  BIGINT NOT NULL,

    ID_VERSION                   BIGINT NOT NULL,

    --------------------------------------------------------------------------
    -- ORDEN
    --------------------------------------------------------------------------

    ORDEN                        INT NOT NULL,

    HORA                         TIME(0) NOT NULL,

    --------------------------------------------------------------------------
    -- DINESAT
    --------------------------------------------------------------------------

    PROGRAMBLOCK_ID_DINESAT      BIGINT NULL,

    PROGRAMEVENT_ID_DINESAT      BIGINT NULL,

    MATERIAL_ID_DINESAT          BIGINT NULL,

    --------------------------------------------------------------------------
    -- MATERIAL
    --------------------------------------------------------------------------

    CODIGO_MATERIAL              NVARCHAR(30) NOT NULL,

    TITULO_MATERIAL              NVARCHAR(250) NOT NULL,

    DURACION_SEGUNDOS            INT NOT NULL,

    --------------------------------------------------------------------------
    -- ESTADO
    --------------------------------------------------------------------------

    TRANSMITIDO                  BIT NOT NULL
        CONSTRAINT DF_GR_PROGDET_TRANSMITIDO DEFAULT(0),

    SINCRONIZADO                 BIT NOT NULL
        CONSTRAINT DF_GR_PROGDET_SINCRONIZADO DEFAULT(0),

    ACTIVO                       BIT NOT NULL
        CONSTRAINT DF_GR_PROGDET_ACTIVO DEFAULT(1),

    --------------------------------------------------------------------------
    -- AUDITORÍA
    --------------------------------------------------------------------------

    FECHA_CREACION               DATETIME2 NOT NULL
        CONSTRAINT DF_GR_PROGDET_FECHA DEFAULT(SYSDATETIME()),

    USUARIO_CREACION             NVARCHAR(100) NOT NULL,

    FECHA_MODIFICACION           DATETIME2 NULL,

    USUARIO_MODIFICACION         NVARCHAR(100) NULL,

    --------------------------------------------------------------------------
    -- PRIMARY KEY
    --------------------------------------------------------------------------

    CONSTRAINT PK_GR_PROGRAMACION_DETALLE
        PRIMARY KEY (ID_PROGRAMACION_DETALLE)
);
GO

/******************************************************************************
    ÍNDICES
******************************************************************************/

CREATE INDEX IX_GR_PROGDET_PROGRAMACION
ON dbo.GR_PROGRAMACION_DETALLE(ID_PROGRAMACION);
GO

CREATE INDEX IX_GR_PROGDET_BLOQUE
ON dbo.GR_PROGRAMACION_DETALLE(ID_BLOQUE);
GO

CREATE INDEX IX_GR_PROGDET_HORA
ON dbo.GR_PROGRAMACION_DETALLE(HORA);
GO

CREATE INDEX IX_GR_PROGDET_CAMPANIA
ON dbo.GR_PROGRAMACION_DETALLE(ID_CAMPANIA);
GO

CREATE INDEX IX_GR_PROGDET_VERSION
ON dbo.GR_PROGRAMACION_DETALLE(ID_VERSION);
GO

CREATE INDEX IX_GR_PROGDET_EVENTO
ON dbo.GR_PROGRAMACION_DETALLE(PROGRAMEVENT_ID_DINESAT);
GO

/******************************************************************************
    FOREIGN KEYS
******************************************************************************/

ALTER TABLE dbo.GR_PROGRAMACION_DETALLE
ADD CONSTRAINT FK_GR_PROGDET_PROGRAMACION
FOREIGN KEY(ID_PROGRAMACION)
REFERENCES dbo.GR_PROGRAMACION(ID_PROGRAMACION);
GO

ALTER TABLE dbo.GR_PROGRAMACION_DETALLE
ADD CONSTRAINT FK_GR_PROGDET_CAMPANIA
FOREIGN KEY(ID_CAMPANIA)
REFERENCES dbo.GR_CAMPANIA(ID_CAMPANIA);
GO

ALTER TABLE dbo.GR_PROGRAMACION_DETALLE
ADD CONSTRAINT FK_GR_PROGDET_VERSION
FOREIGN KEY(ID_VERSION)
REFERENCES dbo.GR_VERSION(ID_VERSION);
GO

ALTER TABLE dbo.GR_PROGRAMACION_DETALLE
ADD CONSTRAINT FK_GR_PROGDET_CLIENTE
FOREIGN KEY(ID_CLIENTE)
REFERENCES dbo.GR_CLIENTE(ID_CLIENTE);
GO

ALTER TABLE dbo.GR_PROGRAMACION_DETALLE
ADD CONSTRAINT FK_GR_PROGDET_BLOQUE
FOREIGN KEY(ID_BLOQUE)
REFERENCES dbo.GR_PARRILLA_BLOQUE(ID_PARRILLA_BLOQUE);
GO