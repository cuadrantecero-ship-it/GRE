using Microsoft.AspNetCore.Mvc;
using GestionRadio.Application.DTOs;
using GestionRadio.Application.Interfaces;

namespace GestionRadio.Web.Controllers;

public class ClientesController : Controller
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    // ============================
    // LISTADO
    // ============================
    public async Task<IActionResult> Index()
    {
        var clientes = await _clienteService.ObtenerTodosAsync();
        return View(clientes);
    }

    // ============================
    // NUEVO
    // ============================
    [HttpGet]
    public IActionResult Create()
    {
        return View(new ClienteCreateDto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClienteCreateDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await _clienteService.CrearAsync(dto);

        TempData["Success"] = "Cliente registrado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    // ============================
    // EDITAR
    // ============================
    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var cliente = await _clienteService.ObtenerPorIdAsync(id);

        if (cliente == null)
            return NotFound();

        var dto = new ClienteUpdateDto
        {
            IdCliente = cliente.IdCliente,
            RazonSocial = cliente.RazonSocial,
            NombreComercial = cliente.NombreComercial,
            RFC = cliente.RFC,
            RegimenFiscal = cliente.RegimenFiscal,
            UsoCFDI = cliente.UsoCFDI,
            Contacto = cliente.Contacto,
            Telefono = cliente.Telefono,
            WhatsApp = cliente.WhatsApp,
            Email = cliente.Email,
            Calle = cliente.Calle,
            NumeroExterior = cliente.NumeroExterior,
            NumeroInterior = cliente.NumeroInterior,
            Colonia = cliente.Colonia,
            Ciudad = cliente.Ciudad,
            Estado = cliente.Estado,
            CodigoPostal = cliente.CodigoPostal,
            LimiteCredito = cliente.LimiteCredito,
            DiasCredito = cliente.DiasCredito,
            Activo = cliente.Activo
        };

        return View(dto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ClienteUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await _clienteService.ActualizarAsync(dto);

        TempData["Success"] = "Cliente actualizado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    // ============================
    // DESACTIVAR
    // ============================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _clienteService.EliminarAsync(id);
            TempData["Success"] = "Cliente desactivado correctamente.";
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }

    // ============================
    // REACTIVAR
    // ============================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reactivar(long id)
    {
        try
        {
            await _clienteService.ReactivarAsync(id);
            TempData["Success"] = "Cliente reactivado correctamente.";
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }
}