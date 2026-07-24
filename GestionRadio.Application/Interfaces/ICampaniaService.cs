using GestionRadio.Application.DTOs;

namespace GestionRadio.Application.Interfaces;

public interface ICampaniaService
{
    Task<IEnumerable<CampaniaDto>> ObtenerTodosAsync();

    Task<CampaniaDto?> ObtenerPorIdAsync(long id);

    Task CrearAsync(CampaniaCreateDto dto);

    Task ActualizarAsync(CampaniaUpdateDto dto);

    Task EliminarAsync(long id);
}