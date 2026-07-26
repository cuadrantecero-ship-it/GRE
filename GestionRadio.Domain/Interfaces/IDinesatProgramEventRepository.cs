using GestionRadio.Domain.Entities;

namespace GestionRadio.Domain.Interfaces;

/// <summary>
/// Acceso a los eventos programados de Dinesat.
/// Corresponde a la tabla PROGRAMEVENT.
/// </summary>
public interface IDinesatProgramEventRepository
{
    Task<IReadOnlyList<DinesatProgramEvent>> ObtenerPorBloqueAsync(long programBlockId);

    Task<DinesatProgramEvent?> ObtenerPorIdAsync(long programEventId);

    Task<int> ObtenerSiguienteItemOrderAsync(long programBlockId);

    /// <summary>
    /// Inserta un evento en PROGRAMEVENT y devuelve el PGMEVENTID generado.
    /// </summary>
    Task<long> InsertarAsync(DinesatProgramEvent evento);
}