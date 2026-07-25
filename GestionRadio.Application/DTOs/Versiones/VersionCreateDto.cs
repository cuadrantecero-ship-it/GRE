namespace GestionRadio.Application.DTOs.Versiones;

public class VersionCreateDto
{
    public long IdCampania { get; set; }

    public long MaterialIdDinesat { get; set; }

    public string CodigoMaterial { get; set; } = string.Empty;

    public string TituloMaterial { get; set; } = string.Empty;

    public int DuracionSegundos { get; set; }

    public int OrdenRotacion { get; set; }

    public bool Preferente { get; set; }
}