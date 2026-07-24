using GestionRadio.Web.Models.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc;

namespace GestionRadio.Web.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var model = new HeaderViewModel
        {
            Sistema = "GESTIÓN RADIO ERP",
            Emisora = "XHEPX FM 90.1",
            Usuario = "Administrador",
            Version = "v1.0.0",
            SqlConectado = true,
            DinesatConectado = true
        };

        return View(model);
    }
}