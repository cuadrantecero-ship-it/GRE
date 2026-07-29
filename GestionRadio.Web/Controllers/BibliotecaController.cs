using GestionRadio.Application.Interfaces;
using GestionRadio.Web.Models.ViewModels.Dinesat;
using Microsoft.AspNetCore.Mvc;

namespace GestionRadio.Web.Controllers;

public sealed class BibliotecaController : Controller
{
    private readonly IDinesatMaterialService _materialService;

    public BibliotecaController(
        IDinesatMaterialService materialService)
    {
        _materialService = materialService;
    }

    public async Task<IActionResult> Index()
    {
        var materiales = await _materialService.ObtenerActivosAsync();

        var model = new DinesatExplorerViewModel
        {
            Materiales = materiales,
            CategoriaSeleccionada = "SPOT"
        };

        return View(model);
    }
}