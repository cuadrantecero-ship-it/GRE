using GestionRadio.Application.DTOs.Versiones;

namespace GestionRadio.Application.Interfaces;

public interface IVersionService
{
    Task<IEnumerable<VersionDto>> ObtenerTodosAsync();

    Task<VersionDto?> ObtenerPorIdAsync(long id);

    Task CrearAsync(VersionCreateDto dto);

    Task ActualizarAsync(VersionUpdateDto dto);

    Task EliminarAsync(long id);
}