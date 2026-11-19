using DSWI_T1_01.Models;

namespace DSWI_T1_01.Services;

public interface ICitaService
{
    Task<List<Cita>> ObtenerTodosAsync();
    Task<Cita?> ObtenerPorIdAsync(int id);
    Task CrearAsync(Cita entidad);
    Task EditarAsync(Cita entidad);
    Task EliminarAsync(int id);
}
