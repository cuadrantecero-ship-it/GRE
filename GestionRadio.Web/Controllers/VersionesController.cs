using GestionRadio.Application.DTOs.Versiones;
using GestionRadio.Application.Interfaces;
using GestionRadio.Web.Models.ViewModels.Versiones;
using Microsoft.AspNetCore.Mvc;

namespace GestionRadio.Web.Controllers;

public class VersionesController : Controller
{
    private readonly IVersionService _versionService;
    private readonly ICampaniaService _campaniaService;
    private readonly IDinesatMaterialService _materialService;

    public VersionesController(
        IVersionService versionService,
        ICampaniaService campaniaService,
        IDinesatMaterialService materialService)
    {
        _versionService = versionService;
        _campaniaService = campaniaService;
        _materialService = materialService;
    }

    //========================================================
    // LISTADO
    //========================================================

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var datos = await _versionService.ObtenerTodosAsync();

        var modelo = datos.Select(v => new VersionesViewModel
{
    IdVersion = v.IdVersion,
    IdCampania = v.IdCampania,

            // IMPORTANTE:
            // VersionesViewModel todavía usa MaterialId.
            MaterialIdDinesat = v.MaterialIdDinesat,

            CodigoMaterial = v.CodigoMaterial,
    TituloMaterial = v.TituloMaterial,
    DuracionSegundos = v.DuracionSegundos,

    OrdenRotacion = v.OrdenRotacion,
    Preferente = v.Preferente,
    Activo = v.Activo

}).ToList();

        return View(modelo);
    }

    //========================================================
    // NUEVA VERSION
    //========================================================

    [HttpGet]
    public async Task<IActionResult> Nueva()
    {
        var campanias = await _campaniaService.ObtenerTodosAsync();

        var model = new VersionesViewModel
        {
            Activo = true,
            OrdenRotacion = 1,

            Campanias = campanias.Select(c => new CampaniaItemViewModel
            {
                IdCampania = c.IdCampania,
                Nombre = c.Nombre

            }).ToList()
        };

        return PartialView("_NuevaVersionModal", model);
    }

    //========================================================
    // BUSCAR MATERIAL
    //========================================================

    [HttpGet]
    public async Task<IActionResult> BuscarMaterial(string codigo)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                return Json(new
                {
                    ok = false,
                    mensaje = "Debe indicar un código."
                });
            }

            var material = await _materialService.ObtenerPorCodigoAsync(codigo);

            if (material == null)
            {
                return Json(new
                {
                    ok = false,
                    mensaje = "No existe el material en Dinesat."
                });
            }

            return Json(new
            {
                ok = true,

                materialId = material.MaterialIdDinesat,

                codigoMaterial = material.Codigo,

                tituloMaterial = material.Titulo,

                duracionSegundos = material.Duracion / 1000
            });
        }
        catch (Exception ex)
        {
            return Json(new
            {
                ok = false,
                mensaje = ex.Message
            });
        }
    }

    //========================================================
    // GUARDAR
    //========================================================

    [HttpPost]
    public async Task<IActionResult> Guardar([FromBody] VersionCreateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    ok = false,
                    mensaje = "La información recibida no es válida."
                });
            }

            await _versionService.CrearAsync(dto);

            return Json(new
            {
                ok = true,
                mensaje = "La versión fue registrada correctamente."
            });
        }
        catch (Exception ex)
        {
            return Json(new
            {
                ok = false,
                mensaje = ex.Message
            });
        }
    }
}