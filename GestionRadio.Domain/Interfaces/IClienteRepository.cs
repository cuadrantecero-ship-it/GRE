using GestionRadio.Domain.Entities;

namespace GestionRadio.Domain.Interfaces;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> ObtenerTodosAsync();

    Task<Cliente?> ObtenerPorIdAsync(long id);

    Task<Cliente?> ObtenerPorFolioAsync(string folio);

    Task<long> InsertarAsync(Cliente cliente);

    Task ActualizarAsync(Cliente cliente);

    /// <summary>
    /// Cambia el estado lógico del cliente.
    /// activo = true  -> Reactiva
    /// activo = false -> Desactiva
    /// </summary>
    Task CambiarEstadoAsync(long id, bool activo);

    Task<bool> ExisteFolioAsync(string folio);
}