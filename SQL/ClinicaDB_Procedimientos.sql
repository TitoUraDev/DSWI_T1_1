USE ClinicaBD;
GO
CREATE OR ALTER PROCEDURE dbo.usp_Pacientes_Listar AS BEGIN SET NOCOUNT ON; SELECT PacienteID,Nombre,DNI FROM dbo.Pacientes ORDER BY PacienteID; END;
GO
CREATE OR ALTER PROCEDURE dbo.usp_Pacientes_ObtenerPorId @PacienteID INT AS BEGIN SET NOCOUNT ON; SELECT PacienteID,Nombre,DNI FROM dbo.Pacientes WHERE PacienteID=@PacienteID; END;
GO
CREATE OR ALTER PROCEDURE dbo.usp_Pacientes_Crear @Nombre NVARCHAR(100),@DNI NVARCHAR(20),@NuevoID INT OUTPUT AS BEGIN SET NOCOUNT ON; INSERT dbo.Pacientes(Nombre,DNI) VALUES(@Nombre,@DNI); SET @NuevoID=CONVERT(INT,SCOPE_IDENTITY()); END;
GO
CREATE OR ALTER PROCEDURE dbo.usp_Pacientes_Editar @PacienteID INT,@Nombre NVARCHAR(100),@DNI NVARCHAR(20) AS BEGIN SET NOCOUNT ON; UPDATE dbo.Pacientes SET Nombre=@Nombre,DNI=@DNI WHERE PacienteID=@PacienteID; END;
GO
CREATE OR ALTER PROCEDURE dbo.usp_Citas_Listar AS BEGIN SET NOCOUNT ON; SELECT CitaID,Fecha,Hora,Especialidad,Estado,PacienteID FROM dbo.Citas ORDER BY Fecha,Hora; END;
GO
CREATE OR ALTER PROCEDURE dbo.usp_Citas_ObtenerPorId @CitaID INT AS BEGIN SET NOCOUNT ON; SELECT CitaID,Fecha,Hora,Especialidad,Estado,PacienteID FROM dbo.Citas WHERE CitaID=@CitaID; END;
GO
CREATE OR ALTER PROCEDURE dbo.usp_Citas_Crear @Fecha DATE,@Hora TIME,@Especialidad NVARCHAR(50),@Estado NVARCHAR(20),@PacienteID INT,@NuevoID INT OUTPUT AS BEGIN SET NOCOUNT ON; INSERT dbo.Citas(Fecha,Hora,Especialidad,Estado,PacienteID) VALUES(@Fecha,@Hora,@Especialidad,@Estado,@PacienteID); SET @NuevoID=CONVERT(INT,SCOPE_IDENTITY()); END;
GO
CREATE OR ALTER PROCEDURE dbo.usp_Citas_Editar @CitaID INT,@Fecha DATE,@Hora TIME,@Especialidad NVARCHAR(50),@Estado NVARCHAR(20),@PacienteID INT AS BEGIN SET NOCOUNT ON; UPDATE dbo.Citas SET Fecha=@Fecha,Hora=@Hora,Especialidad=@Especialidad,Estado=@Estado,PacienteID=@PacienteID WHERE CitaID=@CitaID; END;
GO