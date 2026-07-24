using GestionRadio.Application.DTOs;

namespace GestionRadio.Application.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<ClienteDto>> ObtenerTodosAsync();

    Task<ClienteDto?> ObtenerPorIdAsync(long id);

    Task<long> CrearAsync(ClienteCreateDto dto);

    Task ActualizarAsync(ClienteUpdateDto dto);

    /// <summary>
    /// Desactiva lógicamente un cliente.
    /// </summary>
    Task EliminarAsync(long id);

    /// <summary>
    /// Reactiva un cliente previamente desactivado.
    /// </summary>
    Task ReactivarAsync(long id);
}