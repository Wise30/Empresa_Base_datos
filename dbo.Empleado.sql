CREATE TABLE [dbo].[Empleado] (
    [Id_empleado]      INT          IDENTITY (1, 1) NOT NULL,
    [nombre]           VARCHAR (30) NOT NULL,
    [apellido]         VARCHAR (40) NOT NULL,
    [fecha_nacimiento] DATETIME         NOT NULL,
    [cedula_pasaporte] NCHAR(16) NOT NULL,
    [movil]            NCHAR(16) NULL,
    [telefono]         NCHAR(16) NULL,
    [direccion]        VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id_empleado] ASC)
);

