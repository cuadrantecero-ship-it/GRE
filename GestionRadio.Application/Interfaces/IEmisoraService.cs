using GestionRadio.Application.DTOs.Emisora;

namespace GestionRadio.Application.Interfaces;

public interface IEmisoraService
{
    Task<IEnumerable<EmisoraDto>> ObtenerTodasAsync();

    Task<IEnumerable<EmisoraDto>> ObtenerActivasAsync();

    Task<EmisoraDto?> ObtenerPorIdAsync(long id);
}