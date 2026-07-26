namespace GestionRadio.Domain.Entities;

public class TipoEvento
{
    public int TipoEventoId { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public bool PermitePublicidad { get; set; }

    public bool Activo { get; set; }
}