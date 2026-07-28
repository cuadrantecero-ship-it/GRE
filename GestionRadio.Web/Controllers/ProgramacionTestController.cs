using GestionRadio.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionRadio.Web.Controllers;

public class ProgramacionTestController : Controller
{
    private readonly IProgramacionEngineService _engine;

    public ProgramacionTestController(
        IProgramacionEngineService engine)
    {
        _engine = engine
            ?? throw new ArgumentNullException(nameof(engine));
    }


    [HttpGet]
    public IActionResult Index()
    {
        return Content(
            "Controlador de prueba de Programación activo.");
    }


    [HttpGet]
    public async Task<IActionResult> Ejecutar(long id)
    {
        if (id <= 0)
        {
            return BadRequest(
                "Debe enviar el ID de la programación.");
        }


        var resultado =
            await _engine.ProgramarAsync(id);


        return Json(resultado);
    }
}