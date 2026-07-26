namespace GestionRadio.Application.DTOs;

public class ParrillaUpdateDto
{
    public long ParrillaId { get; set; }

    public long EmisoraId { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public bool Activa { get; set; }
}