using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_01.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();

    public IActionResult Error() => Content("Ocurrió un error al procesar la solicitud.");
}
