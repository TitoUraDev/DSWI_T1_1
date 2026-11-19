using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_01.Models.ViewModels;

public class EnvioViewModel
{
    [Required(ErrorMessage = "Ingrese el peso del paquete.")]
    [Range(typeof(decimal), "0.01", "999999", ErrorMessage = "El peso debe ser mayor que cero.")]
    [Display(Name = "Peso del paquete (kg)")]
    public decimal? Peso { get; set; }

    [Display(Name = "¿Envío internacional?")]
    public bool EsInternacional { get; set; }

    public EnvioResultado? Resultado { get; set; }
}

public class EnvioResultado
{
    public decimal Peso { get; set; }
    public bool EsInternacional { get; set; }
    public decimal TarifaPorKilo { get; set; }
    public decimal Recargo { get; set; }
    public decimal Total { get; set; }
}
