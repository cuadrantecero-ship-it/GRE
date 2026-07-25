using GestionRadio.Application.DTOs.Programacion;

namespace GestionRadio.Application.Interfaces;

public interface IProgramacionService
{
    Task<IEnumerable<ProgramacionDto>> ObtenerTodosAsync();

    Task<ProgramacionDto?> ObtenerPorIdAsync(long id);

    Task<long> CrearAsync(ProgramacionCreateDto dto);

    Task ActualizarAsync(ProgramacionDto dto);

    Task EliminarAsync(long id);
}