using DSWI_T1_01.Data;
using DSWI_T1_01.Models;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_01.Repositories;

// Todas las operaciones se ejecutan mediante procedimientos almacenados
public class PacienteRepository : IPacienteRepository
{
    private readonly ClinicaBdContext _context;

    public PacienteRepository(ClinicaBdContext context)
    {
        _context = context;
    }

    public async Task<List<Paciente>> ObtenerTodosAsync()
    {
        return await _context.Pacientes
            .FromSqlInterpolated($"EXEC dbo.usp_Pacientes_Listar")
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Paciente?> ObtenerPorIdAsync(int id)
    {
        var lista = await _context.Pacientes
            .FromSqlInterpolated($"EXEC dbo.usp_Pacientes_ObtenerPorId {id}")
            .AsNoTracking()
            .ToListAsync();
        return lista.FirstOrDefault();
    }

    public async Task CrearAsync(Paciente entidad)
    {
        await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.usp_Pacientes_Crear {entidad.Nombre}, {entidad.Dni}");
    }

    public async Task EditarAsync(Paciente entidad)
    {
        await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.usp_Pacientes_Editar {entidad.PacienteId}, {entidad.Nombre}, {entidad.Dni}");
    }

    public async Task EliminarAsync(int id)
    {
        await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.usp_Pacientes_Eliminar {id}");
    }
}
