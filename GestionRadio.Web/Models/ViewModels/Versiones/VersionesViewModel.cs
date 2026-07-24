namespace GestionRadio.Web.Models.ViewModels.Versiones;

public class VersionesViewModel
{
    //=========================
    // Identificadores
    //=========================

    public int IdVersion { get; set; }

    public int IdCampania { get; set; }

    //=========================
    // Información Campaña
    //=========================

    public string NombreCampania { get; set; } = string.Empty;

    //=========================
    // Material Dinesat
    //=========================

    public long MaterialId { get; set; }

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
    public int IdCampania { get; set; }

    public string Nombre { get; set; } = string.Empty;
}