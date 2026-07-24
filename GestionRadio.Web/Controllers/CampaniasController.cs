using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionRadio.Application.DTOs;
using GestionRadio.Application.Interfaces;

namespace GestionRadio.Web.Controllers;

public class CampaniasController : Controller
{
    private readonly ICampaniaService _campaniaService;
    private readonly IClienteService _clienteService;

    public CampaniasController(
        ICampaniaService campaniaService,
        IClienteService clienteService)
    {
        _campaniaService = campaniaService;
        _clienteService = clienteService;
    }

    //===========================
    // MÉTODO PRIVADO
    //===========================
    private async Task CargarClientes(long? seleccionado = null)
    {
        var clientes = await _clienteService.ObtenerTodosAsync();

        ViewBag.Clientes = clientes
            .Where(c => c.Activo)
            .OrderBy(c => c.RazonSocial)
            .Select(c => new SelectListItem
            {
                Value = c.IdCliente.ToString(),
                Text = c.RazonSocial,
                Selected = seleccionado == c.IdCliente
            })
            .ToList();
    }

    //===========================
    // LISTADO
    //===========================
    public async Task<IActionResult> Index()
    {
        var campanias = await _campaniaService.ObtenerTodosAsync();
        return View(campanias);
    }

    //===========================
    // NUEVO
    //===========================
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await CargarClientes();

        return View(new CampaniaCreateDto
        {
            FechaInicio = DateOnly.FromDateTime(DateTime.Today),
            FechaFin = DateOnly.FromDateTime(DateTime.Today),
            Prioridad = 3
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CampaniaCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            await CargarClientes(dto.IdCliente);
            return View(dto);
        }

        await _campaniaService.CrearAsync(dto);

        TempData["Success"] = "Campaña registrada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    //===========================
    // EDITAR
    //===========================
    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var campania = await _campaniaService.ObtenerPorIdAsync(id);

        if (campania == null)
            return NotFound();

        await CargarClientes(campania.IdCliente);

        var dto = new CampaniaUpdateDto
        {
            IdCampania = campania.IdCampania,
            IdCliente = campania.IdCliente,
            Nombre = campania.Nombre,
            Descripcion = campania.Descripcion,
            FechaInicio = campania.FechaInicio,
            FechaFin = campania.FechaFin,
            Prioridad = campania.Prioridad,
            Estado = campania.Estado,
            Activo = campania.Activo
        };

        return View(dto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CampaniaUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            await CargarClientes(dto.IdCliente);
            return View(dto);
        }

        await _campaniaService.ActualizarAsync(dto);

        TempData["Success"] = "Campaña actualizada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    //===========================
    // BAJA LÓGICA
    //===========================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _campaniaService.EliminarAsync(id);

            TempData["Success"] = "Campaña desactivada correctamente.";
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }
}