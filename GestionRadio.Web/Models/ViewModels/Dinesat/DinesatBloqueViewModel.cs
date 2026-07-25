namespace GestionRadio.Web.Models.ViewModels.Dinesat;

/// <summary>
/// Representa un bloque horario de Dinesat con todos sus eventos.
/// </summary>
public sealed class DinesatBloqueViewModel
{
    /// <summary>
    /// Identificador del bloque.
    /// </summary>
    public long ProgramBlockId { get; set; }

    /// <summary>
    /// Hora del bloque tal como la almacena Dinesat
    /// (ejemplo: "05:30:00").
    /// </summary>
    public string HoraInicio { get; set; } = string.Empty;

    /// <summary>
    /// Nombre o descripción del bloque.
    /// </summary>
    public string Nombre { get; set; } = string.Empty;

    /// <summary>
    /// Eventos contenidos en el bloque.
    /// </summary>
    public List<DinesatEventoViewModel> Eventos { get; set; } = new();
}