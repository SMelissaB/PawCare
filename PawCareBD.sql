
CREATE DATABASE PawCareDB;
GO

USE PawCareDB;
GO

CREATE TABLE Mascotas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreMascota VARCHAR(100) NOT NULL,
    NombreDueno VARCHAR(100) NOT NULL,
    Tipo VARCHAR(50) NOT NULL, 
    Edad INT NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    Observaciones VARCHAR(255) NULL 
);
GO

CREATE PROCEDURE spListarMascotas
AS
BEGIN
    SELECT 
        Id, 
        NombreMascota, 
        NombreDueno, 
        Tipo, 
        Edad, 
        Telefono, 
        Observaciones
    FROM Mascotas;
END;
GO

CREATE PROCEDURE spInsertarMascota
    @NombreMascota VARCHAR(100),
    @NombreDueno VARCHAR(100),
    @Tipo VARCHAR(50),
    @Edad INT,
    @Telefono VARCHAR(20),
    @Observaciones VARCHAR(255) = NULL
AS
BEGIN
    INSERT INTO Mascotas (NombreMascota, NombreDueno, Tipo, Edad, Telefono, Observaciones)
    VALUES (@NombreMascota, @NombreDueno, @Tipo, @Edad, @Telefono, @Observaciones);
END;
GO



INSERT INTO Mascotas (NombreMascota, NombreDueno, Tipo, Edad, Telefono, Observaciones)
VALUES 
    ('Firulais', 'Carlos López', 'Perro', 3, '987654321', 'Control de vacunas'),
    ('Michi', 'Ana Torres', 'Gato', 2, '912345678', 'Revisión general'),
    ('Bobby', 'Luis Gómez', 'Perro', 5, '998877665', 'Alergia a la piel'),
    ('Luna', 'María Pérez', 'Gato', 1, '945612378', 'Desparasitación'),
    ('Coco', 'Jorge Sánchez', 'Otro', 4, '965432187', 'Loro con plumaje sano');
GO


SELECT * FROM MASCOTAS