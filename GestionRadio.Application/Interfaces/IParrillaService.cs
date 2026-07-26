using GestionRadio.Application.DTOs;
using GestionRadio.Application.DTOs.Parrillas;

namespace GestionRadio.Application.Interfaces;

public interface IParrillaService
{
    Task<IEnumerable<ParrillaDto>> ObtenerTodasAsync();

    Task<ParrillaDto?> ObtenerPorIdAsync(long id);

    Task<long> CrearAsync(ParrillaCreateDto dto);

    Task ActualizarAsync(ParrillaUpdateDto dto);

    Task EliminarAsync(long id);

    // ==========================
    // EVENTOS DE LA PARRILLA
    // ==========================

    Task<IEnumerable<ParrillaEventoDto>> ObtenerEventosAsync(long parrillaId);

    Task GuardarEventosAsync(
        long parrillaId,
        IEnumerable<ParrillaEventoUpdateDto> eventos);

    Task<IEnumerable<TipoEventoDto>> ObtenerTiposEventoAsync();
}