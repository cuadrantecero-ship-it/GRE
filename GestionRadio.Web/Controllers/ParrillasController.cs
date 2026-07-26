using GestionRadio.Application.DTOs;
using GestionRadio.Application.DTOs.Parrillas;
using GestionRadio.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionRadio.Web.Controllers;

public class ParrillasController : Controller
{
    private readonly IParrillaService _service;

    public ParrillasController(IParrillaService service)
    {
        _service = service;
    }

    #region Parrillas

    public async Task<IActionResult> Index()
    {
        var lista = await _service.ObtenerTodasAsync();

        return View(lista);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new ParrillaCreateDto
        {
            FechaInicio = DateOnly.FromDateTime(DateTime.Today)
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ParrillaCreateDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await _service.CrearAsync(dto);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var parrilla = await _service.ObtenerPorIdAsync(id);

        if (parrilla == null)
            return NotFound();

        var dto = new ParrillaUpdateDto
        {
            ParrillaId = parrilla.ParrillaId,
            EmisoraId = parrilla.EmisoraId,
            Nombre = parrilla.Nombre,
            FechaInicio = parrilla.FechaInicio,
            FechaFin = parrilla.FechaFin,
            Activa = parrilla.Activa
        };

        return View(dto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ParrillaUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await _service.ActualizarAsync(dto);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.EliminarAsync(id);

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Eventos

    [HttpGet]
    public async Task<IActionResult> Eventos(long parrillaId)
    {
        ViewBag.ParrillaId = parrillaId;

        var eventos = await _service.ObtenerEventosAsync(parrillaId);

        return View(eventos);
    }

    [HttpGet]
    public async Task<IActionResult> NuevoEvento(long parrillaId)
    {
        ViewBag.ParrillaId = parrillaId;
        ViewBag.TiposEvento = await _service.ObtenerTiposEventoAsync();

        return View(new ParrillaEventoCreateDto
        {
            ParrillaId = parrillaId
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> GuardarEventos(
        long parrillaId,
        List<ParrillaEventoUpdateDto> eventos)
    {
        await _service.GuardarEventosAsync(
            parrillaId,
            eventos);

        return RedirectToAction(
            nameof(Eventos),
            new { parrillaId });
    }

    #endregion
}