namespace GestionRadio.Application.DTOs.Parrilla;

public class TipoEventoDto
{
    public long TipoEventoId { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Codigo { get; set; } = string.Empty;

    public bool Activo { get; set; }
}