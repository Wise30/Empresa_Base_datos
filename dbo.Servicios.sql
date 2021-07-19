CREATE TABLE [dbo].[Servicios]
(
	[Id_servicios] INT NOT NULL PRIMARY KEY, 
    [servicio] VARCHAR(50) NULL, 
    [empresa] VARCHAR(50) NULL, 
    [representante] VARCHAR(50) NULL, 
    [numero_cell_representante] VARCHAR(50) NULL, 
    [direccion_empresa] TEXT NULL, 
    [tipo_servicio] VARCHAR(50) NULL, 
    [id_proyecto_servicio] INT NULL, 
    CONSTRAINT [FK_Servicios_proyecto] FOREIGN KEY ([id_proyecto_servicio]) REFERENCES [Proyecto]([Id_Proyecto])
)
