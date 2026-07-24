using Microsoft.AspNetCore.Mvc;
using GestionRadio.Web.Models.ViewModels.Shared;

namespace GestionRadio.Web.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var model = new HeaderViewModel
        {
            Sistema = "GESTIÓN RADIO",
            Emisora = "XHEPX FM",
            Usuario = "ADMIN",
            Fecha = DateTime.Now,
            SqlConectado = true,
            DinesatConectado = true
        };

        return View(model);
    }
}