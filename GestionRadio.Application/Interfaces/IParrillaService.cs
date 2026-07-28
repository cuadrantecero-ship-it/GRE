using GestionRadio.Application.DTOs.Parrilla;

namespace GestionRadio.Application.Interfaces;

public interface IParrillaService
{
    //=========================================
    // PARRILLAS
    //=========================================

    Task<IEnumerable<ParrillaDto>> ObtenerTodasAsync();


    Task<ParrillaDto?> ObtenerPorIdAsync(
        long id);


    Task<long> CrearAsync(
        ParrillaCreateDto dto);


    Task ActualizarAsync(
        ParrillaUpdateDto dto);


    Task EliminarAsync(
        long id);



    //=========================================
    // EVENTOS
    //=========================================

    Task<IEnumerable<ParrillaEventoDto>> ObtenerEventosAsync(
        long parrillaId);



    Task<IEnumerable<TipoEventoDto>> ObtenerTiposEventoAsync();



    Task CrearEventoAsync(
        long parrillaId,
        ParrillaEventoCreateDto dto);



    Task ActualizarEventoAsync(
        ParrillaEventoUpdateDto dto);



    Task EliminarEventoAsync(
        long eventoId);
}