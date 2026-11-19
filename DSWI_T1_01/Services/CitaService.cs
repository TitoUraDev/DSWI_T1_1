using DSWI_T1_01.Models;
using DSWI_T1_01.Repositories;

namespace DSWI_T1_01.Services;

public class CitaService : ICitaService
{
    private readonly ICitaRepository _repository;

    public CitaService(ICitaRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Cita>> ObtenerTodosAsync() => _repository.ObtenerTodosAsync();

    public Task<Cita?> ObtenerPorIdAsync(int id) => _repository.ObtenerPorIdAsync(id);

    public Task CrearAsync(Cita entidad) => _repository.CrearAsync(entidad);

    public Task EditarAsync(Cita entidad) => _repository.EditarAsync(entidad);

    public Task EliminarAsync(int id) => _repository.EliminarAsync(id);
}
