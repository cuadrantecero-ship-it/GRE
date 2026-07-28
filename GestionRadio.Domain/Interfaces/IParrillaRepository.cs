using GestionRadio.Domain.Entities;

namespace GestionRadio.Domain.Interfaces;

public interface IParrillaRepository
{
    Task<IEnumerable<Parrilla>> ObtenerTodasAsync();

    Task<Parrilla?> ObtenerPorIdAsync(long id);

    Task<long> InsertarAsync(
        Parrilla parrilla);

    Task ActualizarAsync(
        Parrilla parrilla);

    Task EliminarAsync(
        long id);



    //=========================================
    // EVENTOS
    //=========================================

    Task<IEnumerable<ParrillaEvento>> ObtenerEventosAsync(
        long parrillaId);


    Task GuardarEventosAsync(
        long parrillaId,
        IEnumerable<ParrillaEvento> eventos);



    Task<IEnumerable<TipoEvento>> ObtenerTiposEventoAsync();



    //=========================================
    // CRUD EVENTOS INDIVIDUALES
    //=========================================

    Task InsertarEventoAsync(
        ParrillaEvento evento);


    Task ActualizarEventoAsync(
        ParrillaEvento evento);


    Task EliminarEventoAsync(
        long eventoId);



    //=========================================
    // TIMELINE
    //=========================================

    Task<IEnumerable<ParrillaEvento>> ObtenerTimelineAsync(
        long emisoraId,
        DateOnly fecha);
}