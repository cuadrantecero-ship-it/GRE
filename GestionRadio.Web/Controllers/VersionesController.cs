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

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var datos = await _service.ObtenerTodosAsync();

        var modelo = datos.Select(v => new VersionesViewModel
        {
            // Identificadores
            IdVersion = (int)v.IdVersion,
            IdCampania = (int)v.IdCampania,

            // Material Dinesat
            MaterialId = v.MaterialId,
            CodigoMaterial = v.CodigoMaterial,
            TituloMaterial = v.TituloMaterial,
            DuracionSegundos = v.DuracionSegundos,

            // Configuración
            OrdenRotacion = v.OrdenRotacion,
            Preferente = v.Preferente,
            Activo = v.Activo
        }).ToList();

        return View(modelo);
    }

    [HttpGet]
    public IActionResult Nueva()
    {
        var model = new VersionesViewModel
        {
            Activo = true,
            OrdenRotacion = 1
        };

        return PartialView("_NuevaVersionModal", model);
    }
}