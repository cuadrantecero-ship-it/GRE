namespace GestionRadio.Web.Models.ViewModels.Dashboard;

public class DashboardViewModel
{
    // KPIs
    public int TotalClientes { get; set; }

    public int TotalCampanias { get; set; }

    public int TotalVersiones { get; set; }

    public int TotalMaterialesDinesat { get; set; }

    // Estado del sistema
    public bool SqlConectado { get; set; }

    public bool DinesatConectado { get; set; }

    public DateTime UltimaSincronizacion { get; set; }

    // Información general
    public string Emisora { get; set; } = string.Empty;

    public string Usuario { get; set; } = string.Empty;
}