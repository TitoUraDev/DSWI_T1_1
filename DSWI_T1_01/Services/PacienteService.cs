using DSWI_T1_01.Models;
using DSWI_T1_01.Repositories;

namespace DSWI_T1_01.Services;

public class PacienteService : IPacienteService
{
    private readonly IPacienteRepository _repository;

    public PacienteService(IPacienteRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Paciente>> ObtenerTodosAsync() => _repository.ObtenerTodosAsync();

    public Task<Paciente?> ObtenerPorIdAsync(int id) => _repository.ObtenerPorIdAsync(id);

    public Task CrearAsync(Paciente entidad) => _repository.CrearAsync(entidad);

    public Task EditarAsync(Paciente entidad) => _repository.EditarAsync(entidad);

    public Task EliminarAsync(int id) => _repository.EliminarAsync(id);
}
