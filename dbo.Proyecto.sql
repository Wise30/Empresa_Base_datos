CREATE TABLE [dbo].[Proyecto] (
    [Id_Proyecto]     INT          IDENTITY (1, 1) NOT NULL,
    [nombre_proyecto] VARCHAR (50) NOT NULL,
    [fecha_inicio]    DATETIME NOT NULL,
    [lugar_proyecto]  VARCHAR (50) NOT NULL,
    [estado]          VARCHAR(30)   NOT NULL ,
    [presupuesto]     DECIMAL(10, 2)          NOT NULL,
    [descripcion]     TEXT         NOT NULL,
    [encargado]       INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Proyecto] ASC),
    CONSTRAINT [FK_Proyecto_empleado] FOREIGN KEY ([encargado]) REFERENCES [dbo].[Empleado] ([Id_empleado])
);

