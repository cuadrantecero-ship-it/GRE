using GestionRadio.Web.Models.ViewModels.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace GestionRadio.Web.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        var model = new DashboardViewModel
        {
            TotalClientes = 0,
            TotalCampanias = 0,
            TotalVersiones = 0,
            TotalMaterialesDinesat = 742,

            SqlConectado = true,
            DinesatConectado = true,

            UltimaSincronizacion = DateTime.Now,

            Emisora = "XHEPX FM",
            Usuario = "ADMIN"
        };

        return View(model);
    }
}