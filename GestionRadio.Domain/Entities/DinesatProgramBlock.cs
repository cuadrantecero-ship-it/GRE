namespace GestionRadio.Domain.Entities;

/// <summary>
/// Representa un bloque de programación de Dinesat.
/// </summary>
public sealed class DinesatProgramBlock
{
    /// <summary>
    /// Identificador del bloque.
    /// </summary>
    public long ProgramBlockId { get; set; }

    /// <summary>
    /// Identificador de la programación.
    /// </summary>
    public long ProgrammingId { get; set; }

    /// <summary>
    /// Hora del bloque tal como viene almacenada en Dinesat
    /// (ejemplo: "05:30:00").
    /// SQL Server 2008 R2 la almacena como varchar.
    /// </summary>
    public string HoraInicio { get; set; } = string.Empty;

    /// <summary>
    /// Descripción del bloque.
    /// </summary>
    public string Nombre { get; set; } = string.Empty;
}