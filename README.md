# DSWI_T1_1 - Evaluación T1

Proyecto ASP.NET Core MVC en C# para las dos preguntas del documento de evaluación.

## Requisitos
- Visual Studio Community 2026 con SDK .NET 10.
- SQL Server y SQL Server Management Studio.

## Configuración
1. Abra `DSWI_T1_1.csproj` en Visual Studio.
2. En SSMS ejecute el script docente `ClinicaDB.txt` (o el equivalente `SQL/ClinicaDB_Base_Docente.sql` incluido).
3. Ejecute `SQL/ClinicaDB_Procedimientos.sql` para crear los procedimientos almacenados.
4. Revise `appsettings.json` y cambie `Server=localhost` por el nombre de su instancia SQL Server.
5. Restaure NuGet y ejecute con F5.

Paquetes EF Core incluidos en el proyecto: `Microsoft.EntityFrameworkCore.SqlServer` y `Microsoft.EntityFrameworkCore.Tools`, versión 10.0.0. Si desea instalarlos en Package Manager Console: `Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 10.0.0` y `Install-Package Microsoft.EntityFrameworkCore.Tools -Version 10.0.0`.

## Pregunta 01
Calculadora de préstamo y costo de envío. Se considera inclusivo el intervalo 2000-3000 dólares y 10-20 kg. Los demás valores siguen la regla "en los demás casos" del enunciado. El cálculo de cuotas redondea a dos decimales.

## Pregunta 02
Incluye modelos Paciente y Cita, contexto EF Core, interfaces e implementaciones de Repository y Service, DI en Program.cs, consulta por ID y mantenimiento listar/crear/editar mediante procedimientos almacenados.

## Scaffold solicitado
Las clases `Models/Paciente.cs`, `Models/Cita.cs` y `Data/ClinicaDbContext.cs` corresponden al esquema del SQL proporcionado y están listas para usar. Para demostrar Scaffold en Package Manager Console, use (ajustando el servidor):

```powershell
Scaffold-DbContext "Server=localhost;Database=ClinicaBD;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Context ClinicaDbContext -DataAnnotations -Force
```

No vuelva a ejecutar Scaffold sin respaldo porque `-Force` sobrescribe clases existentes. El código fuente se entrega sin base de datos compilada; primero ejecute los scripts SQL.
