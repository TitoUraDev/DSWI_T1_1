CREATE DATABASE ClinicaBD;
GO

-- Usar la base de datos
USE ClinicaBD;
GO

-- Crear tablas
CREATE TABLE Pacientes (
    PacienteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
    DNI NVARCHAR(20)
);

CREATE TABLE Citas (
    CitaID INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE,
    Hora TIME,
    Especialidad NVARCHAR(50),
    Estado NVARCHAR(20),
    PacienteID INT,
    FOREIGN KEY (PacienteID) REFERENCES Pacientes(PacienteID)
);

-- Insertar registros
INSERT INTO Pacientes (Nombre, DNI)
VALUES ('Luis Herrera', '47891234'),
       ('Marina Ruiz', '50912345'),
       ('Diego Bravo', '43098765');

INSERT INTO Citas (Fecha, Hora, Especialidad, Estado, PacienteID)
VALUES ('2025-04-10', '09:30', 'Cardiología', 'Pendiente', 1),
       ('2025-04-11', '10:00', 'Dermatología', 'Confirmada', 2),
       ('2025-04-12', '08:45', 'Pediatría', 'Cancelada', 3);
