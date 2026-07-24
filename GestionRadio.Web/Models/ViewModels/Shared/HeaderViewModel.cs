namespace GestionRadio.Web.Models.ViewModels.Shared;

public class HeaderViewModel
{
    public string Sistema { get; set; } = "GESTIÓN RADIO";

    public string Emisora { get; set; } = "XHEPX FM";

    public string Usuario { get; set; } = "ADMIN";

    public DateTime Fecha { get; set; } = DateTime.Now;

    public bool SqlConectado { get; set; } = true;

    public bool DinesatConectado { get; set; } = true;
}