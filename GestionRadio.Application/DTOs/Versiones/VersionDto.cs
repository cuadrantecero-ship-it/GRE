namespace GestionRadio.Application.DTOs.Versiones;

public class VersionDto
{
    public long IdVersion { get; set; }

    public long IdCampania { get; set; }

    public long MaterialIdDinesat { get; set; }

    public string CodigoMaterial { get; set; } = string.Empty;

    public string TituloMaterial { get; set; } = string.Empty;

    public int DuracionSegundos { get; set; }

    public int OrdenRotacion { get; set; }

    public bool Preferente { get; set; }

    public bool Activo { get; set; }
}