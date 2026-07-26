using GestionRadio.Domain.Entities;

namespace GestionRadio.Domain.Interfaces;

/// <summary>
/// Contrato para acceder a las programaciones de Dinesat.
/// </summary>
public interface IDinesatProgrammingRepository
{
    /// <summary>
    /// Obtiene la programación activa.
    /// </summary>
    Task<DinesatProgramming?> ObtenerActivaAsync();

    /// <summary>
    /// Obtiene una programación por su identificador.
    /// </summary>
    Task<DinesatProgramming?> ObtenerPorIdAsync(long programmingId);

    /// <summary>
    /// Obtiene todas las programaciones.
    /// </summary>
    Task<IReadOnlyList<DinesatProgramming>> ObtenerTodasAsync();

    /// <summary>
    /// Obtiene la programación correspondiente a una fecha y una estación.
    /// </summary>
    Task<DinesatProgramming?> ObtenerPorFechaAsync(
        DateOnly fecha,
        long stationId);
}