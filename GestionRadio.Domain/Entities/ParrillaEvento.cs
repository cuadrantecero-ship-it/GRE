namespace GestionRadio.Domain.Entities;

public class ParrillaEvento
{
    public long EventoId { get; set; }

    public long ParrillaId { get; set; }

    public TimeOnly Hora { get; set; }

    public int TipoEventoId { get; set; }

    public string? Descripcion { get; set; }

    public bool PermitePublicidad { get; set; }

    public int? DuracionMaximaSegundos { get; set; }

    public int Orden { get; set; }
}