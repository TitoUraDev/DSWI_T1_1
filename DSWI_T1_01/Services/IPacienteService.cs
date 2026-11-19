using DSWI_T1_01.Models;

namespace DSWI_T1_01.Services;

public interface IPacienteService
{
    Task<List<Paciente>> ObtenerTodosAsync();
    Task<Paciente?> ObtenerPorIdAsync(int id);
    Task CrearAsync(Paciente entidad);
    Task EditarAsync(Paciente entidad);
    Task EliminarAsync(int id);
}
