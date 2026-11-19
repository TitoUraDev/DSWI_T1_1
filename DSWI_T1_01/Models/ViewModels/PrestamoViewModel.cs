using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_01.Models.ViewModels;

public class PrestamoViewModel
{
    [Required(ErrorMessage = "Ingrese el monto del préstamo.")]
    [Range(typeof(decimal), "0.01", "999999999", ErrorMessage = "El monto debe ser mayor que cero.")]
    [Display(Name = "Monto del préstamo ($)")]
    public decimal? Monto { get; set; }

    public PrestamoResultado? Resultado { get; set; }
}

public class PrestamoResultado
{
    public decimal Monto { get; set; }
    public int Cuotas { get; set; }
    public decimal TasaInteres { get; set; }
    public decimal TotalConInteres { get; set; }
    public decimal ValorCuota { get; set; }
}
