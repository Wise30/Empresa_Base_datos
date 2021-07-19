CREATE TABLE [dbo].[Reserva_Proyecto] (
    [Id_reserva]      INT             NOT NULL,
    [Nombre_proyecto] VARCHAR (50)    NOT NULL,
    [Direccion]       VARCHAR (50)    NULL,
    [Telefono]        NCHAR (12)      NOT NULL,
    [Responsable]     VARCHAR (50)    NOT NULL,
    [Presupuesto]     DECIMAL (10, 2) NOT NULL,
    [Tipo_proyecto]   VARCHAR (30)    NULL,
    [Fecha]           DATE            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_reserva] ASC)
);

