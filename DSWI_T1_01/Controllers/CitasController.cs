using DSWI_T1_01.Models;
using DSWI_T1_01.Models.ViewModels;
using DSWI_T1_01.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSWI_T1_01.Controllers;

public class CitasController : Controller
{
    private static readonly string[] EstadosDisponibles = { "Pendiente", "Confirmada", "Cancelada" };

    private readonly ICitaService _citaService;
    private readonly IPacienteService _pacienteService;

    public CitasController(ICitaService citaService, IPacienteService pacienteService)
    {
        _citaService = citaService;
        _pacienteService = pacienteService;
    }

    public async Task<IActionResult> Index()
    {
        var citas = await _citaService.ObtenerTodosAsync();
        var pacientes = (await _pacienteService.ObtenerTodosAsync())
            .ToDictionary(p => p.PacienteId, p => p.Nombre);

        var lista = citas.Select(c => new CitaListadoViewModel
        {
            CitaId = c.CitaId,
            Fecha = c.Fecha,
            Hora = c.Hora,
            Especialidad = c.Especialidad,
            Estado = c.Estado,
            PacienteNombre = c.PacienteId.HasValue && pacientes.TryGetValue(c.PacienteId.Value, out var n) ? n : "-"
        }).ToList();

        return View(lista);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var model = new CitaFormViewModel();
        await CargarCombosAsync(model);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CitaFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await CargarCombosAsync(model);
            return View(model);
        }

        await _citaService.CrearAsync(AEntidad(model));
        TempData["Mensaje"] = "Cita registrada correctamente.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var cita = await _citaService.ObtenerPorIdAsync(id);
        if (cita is null) return NotFound();

        var model = new CitaFormViewModel
        {
            CitaId = cita.CitaId,
            Fecha = cita.Fecha,
            Hora = cita.Hora,
            Especialidad = cita.Especialidad,
            Estado = cita.Estado,
            PacienteId = cita.PacienteId
        };
        await CargarCombosAsync(model);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, CitaFormViewModel model)
    {
        if (id != model.CitaId) return BadRequest();
        if (!ModelState.IsValid)
        {
            await CargarCombosAsync(model);
            return View(model);
        }

        await _citaService.EditarAsync(AEntidad(model));
        TempData["Mensaje"] = "Cita actualizada correctamente.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _citaService.EliminarAsync(id);
        TempData["Mensaje"] = "Cita eliminada correctamente.";
        return RedirectToAction(nameof(Index));
    }

    private async Task CargarCombosAsync(CitaFormViewModel model)
    {
        var pacientes = await _pacienteService.ObtenerTodosAsync();
        model.Pacientes = pacientes.Select(p => new SelectListItem
        {
            Value = p.PacienteId.ToString(),
            Text = $"{p.Nombre} ({p.Dni})"
        }).ToList();
        model.Estados = EstadosDisponibles.Select(e => new SelectListItem { Value = e, Text = e }).ToList();
    }

    private static Cita AEntidad(CitaFormViewModel m) => new()
    {
        CitaId = m.CitaId,
        Fecha = m.Fecha,
        Hora = m.Hora,
        Especialidad = m.Especialidad,
        Estado = m.Estado,
        PacienteId = m.PacienteId
    };
}
