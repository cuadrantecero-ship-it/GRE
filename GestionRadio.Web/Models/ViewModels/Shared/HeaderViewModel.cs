namespace GestionRadio.Web.Models.ViewModels.Shared;

public class HeaderViewModel
{
    public string Sistema { get; set; } = "GESTIÓN RADIO ERP";

    public string Emisora { get; set; } = "XHEPX FM 90.1";

    public string Usuario { get; set; } = "Administrador";

    public string Version { get; set; } = "v1.0.0";

    public bool SqlConectado { get; set; } = true;

    public bool DinesatConectado { get; set; } = true;
}