using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSWI_T1_01.Models.ViewModels;

public class CitaFormViewModel
{
    public int CitaId { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateOnly? Fecha { get; set; }

    [Required(ErrorMessage = "La hora es obligatoria.")]
    public TimeOnly? Hora { get; set; }

    [Required(ErrorMessage = "La especialidad es obligatoria.")]
    [StringLength(50)]
    public string? Especialidad { get; set; }

    [Required(ErrorMessage = "Seleccione el estado.")]
    public string? Estado { get; set; }

    [Required(ErrorMessage = "Seleccione el paciente.")]
    [Display(Name = "Paciente")]
    public int? PacienteId { get; set; }

    // Solo para pintar los combos (no se validan)
    public IEnumerable<SelectListItem>? Pacientes { get; set; }
    public IEnumerable<SelectListItem>? Estados { get; set; }
}

public class CitaListadoViewModel
{
    public int CitaId { get; set; }
    public DateOnly? Fecha { get; set; }
    public TimeOnly? Hora { get; set; }
    public string? Especialidad { get; set; }
    public string? Estado { get; set; }
    public string? PacienteNombre { get; set; }
}
