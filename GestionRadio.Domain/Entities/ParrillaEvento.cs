namespace GestionRadio.Domain.Entities;

public class ParrillaEvento
{
    public long EventoId { get; set; }

    public long ParrillaId { get; set; }

    // NUEVO: Relación opcional con el bloque que originó el evento
    public long? BloqueId { get; set; }

    public TimeOnly Hora { get; set; }

    public int TipoEventoId { get; set; }

    public string? Descripcion { get; set; }

    public bool PermitePublicidad { get; set; }

    public int? DuracionMaximaSegundos { get; set; }

    public int Orden { get; set; }

    // NUEVO: Indica si el Scheduler puede mover este evento
    public bool Editable { get; set; }

    // NUEVO: Prioridad para resolver conflictos
    public int Prioridad { get; set; }

    // Navegación
    public Parrilla? Parrilla { get; set; }

    public ParrillaBloque? Bloque { get; set; }
}