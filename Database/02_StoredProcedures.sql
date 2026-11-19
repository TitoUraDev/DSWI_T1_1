USE ClinicaBD;
GO

-- ===================== PACIENTES =====================
CREATE OR ALTER PROCEDURE dbo.usp_Pacientes_Listar
AS
BEGIN
    SELECT PacienteID, Nombre, DNI
    FROM dbo.Pacientes
    ORDER BY PacienteID;
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_Pacientes_ObtenerPorId
    @PacienteID INT
AS
BEGIN
    SELECT PacienteID, Nombre, DNI
    FROM dbo.Pacientes
    WHERE PacienteID = @PacienteID;
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_Pacientes_Crear
    @Nombre NVARCHAR(100),
    @DNI    NVARCHAR(20)
AS
BEGIN
    INSERT INTO dbo.Pacientes (Nombre, DNI)
    VALUES (@Nombre, @DNI);
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_Pacientes_Editar
    @PacienteID INT,
    @Nombre     NVARCHAR(100),
    @DNI        NVARCHAR(20)
AS
BEGIN
    UPDATE dbo.Pacientes
    SET Nombre = @Nombre,
        DNI    = @DNI
    WHERE PacienteID = @PacienteID;
END
GO

-- Elimina el paciente y, antes, sus citas (evita el error de clave foranea)
CREATE OR ALTER PROCEDURE dbo.usp_Pacientes_Eliminar
    @PacienteID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;
    BEGIN TRY
        DELETE FROM dbo.Citas     WHERE PacienteID = @PacienteID;
        DELETE FROM dbo.Pacientes WHERE PacienteID = @PacienteID;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- ======================= CITAS =======================
CREATE OR ALTER PROCEDURE dbo.usp_Citas_Listar
AS
BEGIN
    SELECT CitaID, Fecha, Hora, Especialidad, Estado, PacienteID
    FROM dbo.Citas
    ORDER BY Fecha, Hora;
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_Citas_ObtenerPorId
    @CitaID INT
AS
BEGIN
    SELECT CitaID, Fecha, Hora, Especialidad, Estado, PacienteID
    FROM dbo.Citas
    WHERE CitaID = @CitaID;
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_Citas_Crear
    @Fecha        DATE,
    @Hora         TIME,
    @Especialidad NVARCHAR(50),
    @Estado       NVARCHAR(20),
    @PacienteID   INT
AS
BEGIN
    INSERT INTO dbo.Citas (Fecha, Hora, Especialidad, Estado, PacienteID)
    VALUES (@Fecha, @Hora, @Especialidad, @Estado, @PacienteID);
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_Citas_Editar
    @CitaID       INT,
    @Fecha        DATE,
    @Hora         TIME,
    @Especialidad NVARCHAR(50),
    @Estado       NVARCHAR(20),
    @PacienteID   INT
AS
BEGIN
    UPDATE dbo.Citas
    SET Fecha        = @Fecha,
        Hora         = @Hora,
        Especialidad = @Especialidad,
        Estado       = @Estado,
        PacienteID   = @PacienteID
    WHERE CitaID = @CitaID;
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_Citas_Eliminar
    @CitaID INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.Citas WHERE CitaID = @CitaID;
END
GO
