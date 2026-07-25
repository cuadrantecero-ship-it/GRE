namespace GestionRadio.Web.Models.ViewModels.Versiones;

public class VersionesViewModel
{
    //=========================
    // Identificadores
    //=========================

    public long IdVersion { get; set; }

    public long IdCampania { get; set; }

    //=========================
    // Información Campaña
    //=========================

    public string NombreCampania { get; set; } = string.Empty;

    //=========================
    // Material Dinesat
    //=========================

    public long MaterialIdDinesat { get; set; }

    public string CodigoMaterial { get; set; } = string.Empty;

    public string TituloMaterial { get; set; } = string.Empty;

    public int DuracionSegundos { get; set; }

    //=========================
    // Configuración
    //=========================

    public int OrdenRotacion { get; set; } = 1;

    public bool Preferente { get; set; }

    public bool Activo { get; set; } = true;

    //=========================
    // Auditoría
    //=========================

    public DateTime FechaAlta { get; set; }

    public string UsuarioAlta { get; set; } = string.Empty;

    //=========================
    // Catálogos
    //=========================

    public IEnumerable<CampaniaItemViewModel> Campanias { get; set; }
        = Enumerable.Empty<CampaniaItemViewModel>();
}

public class CampaniaItemViewModel
{
    public long IdCampania { get; set; }

    public string Nombre { get; set; } = string.Empty;
}