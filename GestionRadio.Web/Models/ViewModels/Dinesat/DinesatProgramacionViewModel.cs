namespace GestionRadio.Web.Models.ViewModels.Dinesat;

/// <summary>
/// Modelo principal de la pantalla de continuidad.
/// </summary>
public sealed class DinesatProgramacionViewModel
{
    public long ProgrammingId { get; set; }

    /// <summary>
    /// Nombre de la emisora.
    /// </summary>
    public string Emisora { get; set; } = "XHEPX 99.9 FM";

    /// <summary>
    /// Fecha de la programación.
    /// </summary>
    public DateTime Fecha { get; set; } = DateTime.Today;

    /// <summary>
    /// Indica si la programación está activa.
    /// </summary>
    public bool Activa { get; set; } = true;

    /// <summary>
    /// Bloques de la programación.
    /// </summary>
    public List<DinesatBloqueViewModel> Bloques { get; set; } = new();

    /// <summary>
    /// Total de bloques.
    /// </summary>
    public int TotalBloques => Bloques.Count;

    /// <summary>
    /// Total de eventos.
    /// </summary>
    public int TotalEventos => Bloques.Sum(b => b.Eventos.Count);
}