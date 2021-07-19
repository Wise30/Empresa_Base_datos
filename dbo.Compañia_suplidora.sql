CREATE TABLE [dbo].[Compañia_suplidora] (
    [Id_proyecto]         INT           NOT NULL,
    [id_reserva]          INT           NOT NULL,
    [dCompañia_suplidora] VARCHAR (50)  NOT NULL,
    [Cargamento]          VARCHAR (30)  NOT NULL,
    [Cantidad]            NCHAR (10)    NOT NULL,
    [Fecha_entrega]       DATE          NOT NULL,
    [Observacion]         VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id_proyecto] ASC),
    CONSTRAINT [FK_Compañia_suplidora_Reserva_Proyecto] FOREIGN KEY ([id_reserva]) REFERENCES [dbo].[Reserva_Proyecto] ([Id_reserva])
);

