using GestionRadio.Application.DTOs.Programacion;
using GestionRadio.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionRadio.Web.Controllers;

public class ProgramacionController : Controller
{
    private readonly IProgramacionService _programacionService;
    private readonly IEmisoraService _emisoraService;
    private readonly IParrillaService _parrillaService;
    private readonly IAutoSchedulerService _autoSchedulerService;

    public ProgramacionController(
        IProgramacionService programacionService,
        IEmisoraService emisoraService,
        IParrillaService parrillaService,
        IAutoSchedulerService autoSchedulerService)
    {
        _programacionService = programacionService
            ?? throw new ArgumentNullException(nameof(programacionService));

        _emisoraService = emisoraService
            ?? throw new ArgumentNullException(nameof(emisoraService));

        _parrillaService = parrillaService
            ?? throw new ArgumentNullException(nameof(parrillaService));

        _autoSchedulerService = autoSchedulerService
            ?? throw new ArgumentNullException(nameof(autoSchedulerService));
    }

    //=========================================================
    // LISTADO
    //=========================================================

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var datos =
            await _programacionService.ObtenerTodosAsync();

        return View(datos);
    }

    //=========================================================
    // NUEVO
    //=========================================================

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await CargarCatalogos();

        var modelo = new ProgramacionCreateDto
        {
            Fecha = DateOnly.FromDateTime(DateTime.Today),
            Estado = 1,
            Activa = true
        };

        return View(modelo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProgramacionCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            await CargarCatalogos();
            return View(dto);
        }

        await _programacionService.CrearAsync(dto);

        TempData["Success"] =
            "La programación fue creada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    //=========================================================
    // GENERAR PROGRAMACIÓN AUTOMÁTICA
    //=========================================================

    [HttpGet]
    public async Task<IActionResult> Generar()
    {
        await CargarCatalogos();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Generar(
        DateOnly fecha,
        long emisoraId,
        long parrillaId)
    {
        await _autoSchedulerService.GenerarProgramacionAsync(
            fecha,
            emisoraId,
            parrillaId);

        TempData["Success"] =
            "Programación generada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    //=========================================================
    // EDITAR
    //=========================================================

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var dto =
            await _programacionService.ObtenerPorIdAsync(id);

        if (dto == null)
            return NotFound();

        await CargarCatalogos();

        return View(dto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProgramacionDto dto)
    {
        if (!ModelState.IsValid)
        {
            await CargarCatalogos();
            return View(dto);
        }

        await _programacionService.ActualizarAsync(dto);

        TempData["Success"] =
            "La programación fue actualizada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    //=========================================================
    // ELIMINAR
    //=========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(long id)
    {
        await _programacionService.EliminarAsync(id);

        TempData["Success"] =
            "La programación fue eliminada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    //=========================================================
    // CATÁLOGOS
    //=========================================================

    private async Task CargarCatalogos()
    {
        ViewBag.Emisoras =
            await _emisoraService.ObtenerActivasAsync();

        ViewBag.Parrillas =
            await _parrillaService.ObtenerTodasAsync();
    }
}