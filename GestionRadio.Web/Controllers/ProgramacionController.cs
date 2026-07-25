using GestionRadio.Application.DTOs.Programacion;
using GestionRadio.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionRadio.Web.Controllers;

public class ProgramacionController : Controller
{
    private readonly IProgramacionService _programacionService;

    public ProgramacionController(IProgramacionService programacionService)
    {
        _programacionService = programacionService;
    }

    //=========================================================
    // LISTADO
    //=========================================================
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var datos = await _programacionService.ObtenerTodosAsync();

        return View(datos);
    }

    //=========================================================
    // NUEVO
    //=========================================================
    [HttpGet]
    public IActionResult Create()
    {
        return View(new ProgramacionCreateDto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProgramacionCreateDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await _programacionService.CrearAsync(dto);

        TempData["Success"] = "La programación fue creada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    //=========================================================
    // EDITAR
    //=========================================================
    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var dto = await _programacionService.ObtenerPorIdAsync(id);

        if (dto == null)
            return NotFound();

        return View(dto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProgramacionDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await _programacionService.ActualizarAsync(dto);

        TempData["Success"] = "La programación fue actualizada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    //=========================================================
    // ELIMINAR (LÓGICO)
    //=========================================================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(long id)
    {
        await _programacionService.EliminarAsync(id);

        TempData["Success"] = "La programación fue eliminada correctamente.";

        return RedirectToAction(nameof(Index));
    }
}