using GestionRadio.Domain.Entities;

namespace GestionRadio.Domain.Interfaces;

public interface IEmisoraRepository
{
    Task<IEnumerable<Emisora>> ObtenerTodasAsync();

    Task<IEnumerable<Emisora>> ObtenerActivasAsync();

    Task<Emisora?> ObtenerPorIdAsync(long id);
}