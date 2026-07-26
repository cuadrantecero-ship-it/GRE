using GestionRadio.Domain.Entities;

namespace GestionRadio.Domain.Interfaces;

public interface IParrillaRepository
{
    Task<IEnumerable<Parrilla>> ObtenerTodasAsync();

    Task<Parrilla?> ObtenerPorIdAsync(long id);

    Task<long> InsertarAsync(Parrilla parrilla);

    Task ActualizarAsync(Parrilla parrilla);

    Task EliminarAsync(long id);

    Task<IEnumerable<ParrillaEvento>> ObtenerEventosAsync(long parrillaId);

    Task GuardarEventosAsync(
        long parrillaId,
        IEnumerable<ParrillaEvento> eventos);

    Task<IEnumerable<TipoEvento>> ObtenerTiposEventoAsync();

    Task<IEnumerable<ParrillaEvento>> ObtenerTimelineAsync(
        long emisoraId,
        DateOnly fecha);
}