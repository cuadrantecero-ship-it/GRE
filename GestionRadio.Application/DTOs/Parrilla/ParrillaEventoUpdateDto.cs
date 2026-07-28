namespace GestionRadio.Application.DTOs.Parrilla;

public class ParrillaEventoUpdateDto
{
    public long ParrillaEventoId { get; set; }

    public long ParrillaId { get; set; }

    public int Orden { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public long TipoEventoId { get; set; }

    public string Descripcion { get; set; } = string.Empty;

    public bool Activo { get; set; }
}