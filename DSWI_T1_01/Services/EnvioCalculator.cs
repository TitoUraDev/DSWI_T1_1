using DSWI_T1_01.Models.ViewModels;

namespace DSWI_T1_01.Services;

/// <summary>Pregunta 1.2 - Tarifa de envío por peso.</summary>
public static class EnvioCalculator
{
    private const decimal RecargoInternacional = 15m;

    public static EnvioResultado Calcular(decimal peso, bool esInternacional)
    {
        decimal tarifaPorKilo;
        if (peso > 50) tarifaPorKilo = 2.50m;
        else if (peso < 5) tarifaPorKilo = 4m;
        else if (peso >= 10 && peso <= 20) tarifaPorKilo = 3m;
        else tarifaPorKilo = 3.50m;

        decimal recargo = esInternacional ? RecargoInternacional : 0m;

        return new EnvioResultado
        {
            Peso = peso,
            EsInternacional = esInternacional,
            TarifaPorKilo = tarifaPorKilo,
            Recargo = recargo,
            Total = Math.Round(peso * tarifaPorKilo + recargo, 2)
        };
    }
}
