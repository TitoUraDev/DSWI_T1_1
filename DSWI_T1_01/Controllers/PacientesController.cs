using DSWI_T1_01.Models;
using DSWI_T1_01.Models.ViewModels;
using DSWI_T1_01.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_01.Controllers;

public class PacientesController : Controller
{
    private readonly IPacienteService _service;

    public PacientesController(IPacienteService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _service.ObtenerTodosAsync());
    }

    [HttpGet]
    public IActionResult Create() => View(new PacienteFormViewModel());

    [HttpPost]
    public async Task<IActionResult> Create(PacienteFormViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _service.CrearAsync(new Paciente { Nombre = model.Nombre, Dni = model.Dni });
        TempData["Mensaje"] = "Paciente registrado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var paciente = await _service.ObtenerPorIdAsync(id);
        if (paciente is null) return NotFound();

        return View(new PacienteFormViewModel
        {
            PacienteId = paciente.PacienteId,
            Nombre = paciente.Nombre,
            Dni = paciente.Dni
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, PacienteFormViewModel model)
    {
        if (id != model.PacienteId) return BadRequest();
        if (!ModelState.IsValid)
            return View(model);

        await _service.EditarAsync(new Paciente
        {
            PacienteId = model.PacienteId,
            Nombre = model.Nombre,
            Dni = model.Dni
        });
        TempData["Mensaje"] = "Paciente actualizado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _service.EliminarAsync(id);
        TempData["Mensaje"] = "Paciente eliminado correctamente (con sus citas asociadas).";
        return RedirectToAction(nameof(Index));
    }
}
