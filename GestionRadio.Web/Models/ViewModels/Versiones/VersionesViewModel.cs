namespace GestionRadio.Web.Models.ViewModels.Versiones;

public class VersionesViewModel
{
    // Identificadores
    public int IdVersion { get; set; }

    public int IdCampania { get; set; }

    // Información Dinesat
    public int MaterialId { get; set; }

    public string CodigoMaterial { get; set; } = string.Empty;

    public string TituloMaterial { get; set; } = string.Empty;

    public int DuracionSegundos { get; set; }

    // Configuración
    public int OrdenRotacion { get; set; }

    public bool Preferente { get; set; }

    public bool Activo { get; set; }

    // Auditoría
    public DateTime FechaAlta { get; set; }

    public string UsuarioAlta { get; set; } = string.Empty;
}