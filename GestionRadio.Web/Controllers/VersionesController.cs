using Microsoft.AspNetCore.Mvc;

namespace GestionRadio.Web.Controllers;

public class VersionesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}