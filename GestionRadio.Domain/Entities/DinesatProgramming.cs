namespace GestionRadio.Domain.Entities;

/// <summary>
/// Representa una programación de Dinesat.
/// Tabla: PROGRAMMING.
/// </summary>
public sealed class DinesatProgramming
{
    /// <summary>
    /// Identificador de la programación.
    /// </summary>
    public long ProgrammingId { get; set; }

    /// <summary>
    /// Estación a la que pertenece.
    /// </summary>
    public long StationId { get; set; }

    /// <summary>
    /// Fecha de la programación.
    /// </summary>
    public DateTime Fecha { get; set; }

    /// <summary>
    /// Tipo de programación.
    /// </summary>
    public int ProgrammingTypeId { get; set; }

    /// <summary>
    /// Indica si la programación está activa.
    /// </summary>
    public bool Activa { get; set; }
}