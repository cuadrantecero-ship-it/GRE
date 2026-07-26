using GestionRadio.Application.DTOs.Programacion;
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
    public async Task<IActionResult> Ejecutar()
    {
        var request = new ProgramacionCreateDto
        {
            // ==============================
            // Datos ERP
            // ==============================

            IdCampania = 1,

            // IMPORTANTE:
            // Cambiar por una versión real de GR_VERSION
            IdVersion = 1,


            // ==============================
            // Dinesat
            // ==============================

            // STATIONID real de Dinesat
            IdEmisora = 1146901,


            // Programación existente en Dinesat
            FechaProgramacion =
                DateOnly.FromDateTime(DateTime.Today),


            // Bloque que vamos a probar
            HoraProgramada =
                new TimeOnly(12, 30),


            // ==============================
            // Material Dinesat
            // ==============================

            CodigoMaterial = "SPO00001",

            TituloMaterial = "PRUEBA SPOT",

            DuracionSegundos = 30,


            // ==============================
            // Estado
            // ==============================

            Orden = 0,

            Transmitido = false,

            Activo = true
        };


        var resultado =
            await _engine.ProgramarAsync(request);


        return Json(resultado);
    }
}