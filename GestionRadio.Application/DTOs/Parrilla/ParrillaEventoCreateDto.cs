namespace GestionRadio.Application.DTOs.Parrilla;

public class ParrillaEventoCreateDto
{
    public TimeSpan Hora { get; set; }

    public int TipoEventoId { get; set; }

    public string? Descripcion { get; set; }

    public bool PermitePublicidad { get; set; }

    public int? DuracionMaximaSegundos { get; set; }

    public int Orden { get; set; }
}