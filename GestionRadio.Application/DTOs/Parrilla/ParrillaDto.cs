namespace GestionRadio.Application.DTOs.Parrilla;

public class ParrillaDto
{
    public long ParrillaId { get; set; }

    public long EmisoraId { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public bool Activa { get; set; }

    public DateTime FechaCreacion { get; set; }
}