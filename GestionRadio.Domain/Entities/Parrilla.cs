namespace GestionRadio.Domain.Entities;

public class Parrilla
{
    public long ParrillaId { get; set; }

    public long EmisoraId { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public bool Activa { get; set; }

    public DateTime FechaCreacion { get; set; }

    public ICollection<ParrillaDia> Dias { get; set; } = new List<ParrillaDia>();

    public ICollection<ParrillaEvento> Eventos { get; set; } = new List<ParrillaEvento>();
}