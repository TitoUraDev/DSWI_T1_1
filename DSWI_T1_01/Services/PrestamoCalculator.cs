using DSWI_T1_01.Models.ViewModels;

namespace DSWI_T1_01.Services;

/// <summary>Pregunta 1.1 - Esquema de cobro de préstamos.</summary>
public static class PrestamoCalculator
{
    public static PrestamoResultado Calcular(decimal monto)
    {
        int cuotas;
        if (monto > 5000) cuotas = 3;
        else if (monto < 1000) cuotas = 1;
        else if (monto >= 2000 && monto <= 3000) cuotas = 2;
        else cuotas = 5;

        decimal tasa = monto < 4000 ? 0.12m : 0.10m;
        decimal total = monto * (1 + tasa);

        return new PrestamoResultado
        {
            Monto = monto,
            Cuotas = cuotas,
            TasaInteres = tasa,
            TotalConInteres = Math.Round(total, 2),
            ValorCuota = Math.Round(total / cuotas, 2)
        };
    }
}
