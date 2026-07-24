namespace GestionRadio.Application.DTOs.Versiones;

public class VersionUpdateDto
{
    public long IdVersion { get; set; }

    public int OrdenRotacion { get; set; }

    public bool Preferente { get; set; }

    public bool Activo { get; set; }
}