using GestionRadio.Infrastructure.Dinesat;
using Microsoft.AspNetCore.Mvc;

namespace GestionRadio.Web.Controllers;

public class DinesatController : Controller
{
    private readonly MaterialRepository _materialRepository;

    public DinesatController(MaterialRepository materialRepository)
    {
        _materialRepository = materialRepository;
    }

    public async Task<IActionResult> Materiales()
    {
        var materiales = await _materialRepository.ObtenerMaterialesAsync();

        return Json(materiales);
    }
}