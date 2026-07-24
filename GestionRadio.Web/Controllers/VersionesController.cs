using GestionRadio.Application.Interfaces;
using GestionRadio.Web.Models.ViewModels.Versiones;
using Microsoft.AspNetCore.Mvc;

namespace GestionRadio.Web.Controllers;

public class VersionesController : Controller
{
    private readonly IVersionService _service;

    public VersionesController(IVersionService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var datos = await _service.ObtenerTodosAsync();

        var modelo = datos.Select(v => new VersionesViewModel
        {
            IdVersion = (int)v.IdVersion,
            IdCampania = (int)v.IdCampania,
            MaterialId = v.MaterialId,
            CodigoMaterial = v.CodigoMaterial,
            TituloMaterial = v.TituloMaterial,
            DuracionSegundos = v.DuracionSegundos,
            OrdenRotacion = v.OrdenRotacion,
            Preferente = v.Preferente,
            Activo = v.Activo
        }).ToList();

        return View(modelo);
    }
}