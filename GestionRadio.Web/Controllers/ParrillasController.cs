using GestionRadio.Application.DTOs.Parrilla;
using GestionRadio.Application.Interfaces;
using GestionRadio.Web.Models.ViewModels.Parrillas;
using Microsoft.AspNetCore.Mvc;

namespace GestionRadio.Web.Controllers;

public class ParrillasController : Controller
{
    private readonly IParrillaService _service;


    public ParrillasController(
        IParrillaService service)
    {
        _service = service;
    }



    //====================================================
    // LISTADO DE PARRILLAS
    //====================================================

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var datos =
            await _service.ObtenerTodasAsync();


        return View(datos);
    }




    //====================================================
    // EVENTOS DE PARRILLA
    //====================================================

    [HttpGet]
    public async Task<IActionResult> Eventos(long id)
    {
        if (id <= 0)
            return BadRequest("Parrilla inválida.");


        var eventos =
            await _service.ObtenerEventosAsync(id);


        ViewBag.ParrillaId = id;


        return View(eventos);
    }




    //====================================================
    // CREAR EVENTO - FORMULARIO
    //====================================================

    [HttpGet]
    public async Task<IActionResult> CrearEvento(long id)
    {
        if (id <= 0)
            return BadRequest("Parrilla inválida.");


        var tipos =
            await _service.ObtenerTiposEventoAsync();


        var modelo = new ParrillaEventoEditViewModel
        {
            ParrillaId = id,

            TiposEvento = tipos
        };


        return View(modelo);
    }





    //====================================================
    // CREAR EVENTO - GUARDAR
    //====================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CrearEvento(
        long id,
        ParrillaEventoCreateDto dto)
    {

        // DEBUG TEMPORAL
        Console.WriteLine(
            "=================================");

        Console.WriteLine(
            $"PARRILLA ID RECIBIDO: {id}");

        Console.WriteLine(
            $"TIPO EVENTO RECIBIDO: {dto.TipoEventoId}");

        Console.WriteLine(
            "=================================");



        if (!ModelState.IsValid)
        {
            var modelo = new ParrillaEventoEditViewModel
            {
                ParrillaId = id,

                Evento = new ParrillaEventoDto
                {
                    Hora = dto.Hora,

                    TipoEventoId =
                        dto.TipoEventoId,

                    Descripcion =
                        dto.Descripcion,

                    PermitePublicidad =
                        dto.PermitePublicidad,

                    DuracionMaximaSegundos =
                        dto.DuracionMaximaSegundos,

                    Orden =
                        dto.Orden
                },

                TiposEvento =
                    await _service.ObtenerTiposEventoAsync()
            };


            return View(modelo);
        }




        await _service.CrearEventoAsync(
            id,
            dto);




        TempData["Success"] =
            "Evento creado correctamente.";



        return RedirectToAction(
            nameof(Eventos),
            new
            {
                id = id
            });
    }





    //====================================================
    // ELIMINAR EVENTO
    //====================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EliminarEvento(
        long id,
        long eventoId)
    {

        await _service.EliminarEventoAsync(
            eventoId);



        TempData["Success"] =
            "Evento eliminado correctamente.";



        return RedirectToAction(
            nameof(Eventos),
            new
            {
                id = id
            });
    }

}