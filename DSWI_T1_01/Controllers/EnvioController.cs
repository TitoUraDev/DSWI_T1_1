using DSWI_T1_01.Models.ViewModels;
using DSWI_T1_01.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_01.Controllers;

public class EnvioController : Controller
{
    [HttpGet]
    public IActionResult Index() => View(new EnvioViewModel());

    [HttpPost]
    public IActionResult Index(EnvioViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        model.Resultado = EnvioCalculator.Calcular(model.Peso!.Value, model.EsInternacional);
        return View(model);
    }
}
