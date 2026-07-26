SET NOCOUNT ON;
GO

/*==============================================================*/
/* ELIMINAR TABLAS (SOLO SI EXISTEN)                             */
/*==============================================================*/

IF OBJECT_ID('dbo.GR_PARRILLA_EVENTO', 'U') IS NOT NULL
    DROP TABLE dbo.GR_PARRILLA_EVENTO;
GO

IF OBJECT_ID('dbo.GR_PARRILLA_DIA', 'U') IS NOT NULL
    DROP TABLE dbo.GR_PARRILLA_DIA;
GO

IF OBJECT_ID('dbo.GR_PARRILLA', 'U') IS NOT NULL
    DROP TABLE dbo.GR_PARRILLA;
GO

IF OBJECT_ID('dbo.GR_TIPO_EVENTO', 'U') IS NOT NULL
    DROP TABLE dbo.GR_TIPO_EVENTO;
GO

/*==============================================================*/
/* CATÁLOGO DE TIPOS                                             */
/*==============================================================*/

CREATE TABLE dbo.GR_TIPO_EVENTO
(
    TipoEventoId INT IDENTITY(1,1) NOT NULL,
    Nombre NVARCHAR(50) NOT NULL,
    PermitePublicidad BIT NOT NULL DEFAULT(0),
    Activo BIT NOT NULL DEFAULT(1),

    CONSTRAINT PK_GR_TIPO_EVENTO
        PRIMARY KEY(TipoEventoId)
);
GO

INSERT INTO dbo.GR_TIPO_EVENTO
(
    Nombre,
    PermitePublicidad
)
VALUES
('IDENTIFICACION',0),
('HORA',0),
('LINER',0),
('AUTOPROMO',0),
('PROMOCION',0),
('PROGRAMA',0),
('CORTE_COMERCIAL',1),
('NOTICIAS',1),
('RTC',0),
('INE',0),
('HIMNO',0),
('MANUAL',1);
GO

/*==============================================================*/
/* PARRILLA                                                      */
/*==============================================================*/

CREATE TABLE dbo.GR_PARRILLA
(
    ParrillaId BIGINT IDENTITY(1,1) NOT NULL,

    EmisoraId BIGINT NOT NULL,

    Nombre NVARCHAR(100) NOT NULL,

    FechaInicio DATE NOT NULL,

    FechaFin DATE NULL,

    Activa BIT NOT NULL DEFAULT(1),

    FechaCreacion DATETIME2 NOT NULL
        DEFAULT(GETDATE()),

    CONSTRAINT PK_GR_PARRILLA
        PRIMARY KEY(ParrillaId)
);
GO

/*==============================================================*/
/* DÍAS DE APLICACIÓN                                             */
/*==============================================================*/

CREATE TABLE dbo.GR_PARRILLA_DIA
(
    ParrillaDiaId BIGINT IDENTITY(1,1) NOT NULL,

    ParrillaId BIGINT NOT NULL,

    DiaSemana TINYINT NOT NULL,

    CONSTRAINT PK_GR_PARRILLA_DIA
        PRIMARY KEY(ParrillaDiaId),

    CONSTRAINT FK_GR_PARRILLA_DIA
        FOREIGN KEY(ParrillaId)
        REFERENCES dbo.GR_PARRILLA(ParrillaId)
);
GO

/*==============================================================*/
/* EVENTOS                                                       */
/*==============================================================*/

CREATE TABLE dbo.GR_PARRILLA_EVENTO
(
    EventoId BIGINT IDENTITY(1,1) NOT NULL,

    ParrillaId BIGINT NOT NULL,

    Hora TIME NOT NULL,

    TipoEventoId INT NOT NULL,

    Descripcion NVARCHAR(200) NULL,

    PermitePublicidad BIT NOT NULL DEFAULT(0),

    DuracionSegundos INT NOT NULL DEFAULT(0),

    DuracionMaximaSegundos INT NULL,

    Orden INT NOT NULL,

    CONSTRAINT PK_GR_PARRILLA_EVENTO
        PRIMARY KEY(EventoId),

    CONSTRAINT FK_GR_PARRILLA_EVENTO_PARRILLA
        FOREIGN KEY(ParrillaId)
        REFERENCES dbo.GR_PARRILLA(ParrillaId),

    CONSTRAINT FK_GR_PARRILLA_EVENTO_TIPO
        FOREIGN KEY(TipoEventoId)
        REFERENCES dbo.GR_TIPO_EVENTO(TipoEventoId)
);
GO