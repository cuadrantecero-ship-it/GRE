namespace GestionRadio.Application.DTOs;

public class ParrillaCreateDto
{
    public long EmisoraId { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }
}