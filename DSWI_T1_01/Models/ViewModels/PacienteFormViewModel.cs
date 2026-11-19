using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_01.Models.ViewModels;

public class PacienteFormViewModel
{
    public int PacienteId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El DNI es obligatorio.")]
    [StringLength(20)]
    [Display(Name = "DNI")]
    public string? Dni { get; set; }
}
