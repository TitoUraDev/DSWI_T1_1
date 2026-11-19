using DSWI_T1_01.Models.ViewModels;
using DSWI_T1_01.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_01.Controllers;

public class PrestamoController : Controller
{
    [HttpGet]
    public IActionResult Index() => View(new PrestamoViewModel());

    [HttpPost]
    public IActionResult Index(PrestamoViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        model.Resultado = PrestamoCalculator.Calcular(model.Monto!.Value);
        return View(model);
    }
}
