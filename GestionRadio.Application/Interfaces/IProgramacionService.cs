using GestionRadio.Application.DTOs.Programacion;

namespace GestionRadio.Application.Interfaces;

public interface IProgramacionService
{
    // ==========================================
    // CABECERA
    // ==========================================

    Task<IEnumerable<ProgramacionDto>> ObtenerTodosAsync();

    Task<ProgramacionDto?> ObtenerPorIdAsync(long id);

    Task<long> CrearAsync(ProgramacionCreateDto dto);

    Task ActualizarAsync(ProgramacionDto dto);

    Task EliminarAsync(long id);

    // ==========================================
    // DETALLES
    // ==========================================

    Task<IEnumerable<ProgramacionDetalleDto>> ObtenerDetallesAsync(long programacionId);

    Task<long> AgregarDetalleAsync(ProgramacionDetalleCreateDto dto);

    Task ActualizarDetalleAsync(ProgramacionDetalleDto dto);

    Task EliminarDetalleAsync(long programacionDetalleId);
}