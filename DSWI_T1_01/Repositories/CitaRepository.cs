using DSWI_T1_01.Data;
using DSWI_T1_01.Models;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_01.Repositories;

// Todas las operaciones se ejecutan mediante procedimientos almacenados
public class CitaRepository : ICitaRepository
{
    private readonly ClinicaBdContext _context;

    public CitaRepository(ClinicaBdContext context)
    {
        _context = context;
    }

    public async Task<List<Cita>> ObtenerTodosAsync()
    {
        return await _context.Citas
            .FromSqlInterpolated($"EXEC dbo.usp_Citas_Listar")
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Cita?> ObtenerPorIdAsync(int id)
    {
        var lista = await _context.Citas
            .FromSqlInterpolated($"EXEC dbo.usp_Citas_ObtenerPorId {id}")
            .AsNoTracking()
            .ToListAsync();
        return lista.FirstOrDefault();
    }

    public async Task CrearAsync(Cita entidad)
    {
        await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.usp_Citas_Crear {entidad.Fecha}, {entidad.Hora}, {entidad.Especialidad}, {entidad.Estado}, {entidad.PacienteId}");
    }

    public async Task EditarAsync(Cita entidad)
    {
        await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.usp_Citas_Editar {entidad.CitaId}, {entidad.Fecha}, {entidad.Hora}, {entidad.Especialidad}, {entidad.Estado}, {entidad.PacienteId}");
    }

    public async Task EliminarAsync(int id)
    {
        await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.usp_Citas_Eliminar {id}");
    }
}
