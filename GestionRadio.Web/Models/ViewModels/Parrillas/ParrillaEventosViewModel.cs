using GestionRadio.Application.DTOs.Parrilla;

namespace GestionRadio.Web.Models.ViewModels.Parrillas;

public class ParrillaEventosViewModel
{
    public long ParrillaId { get; set; }


    public string NombreParrilla { get; set; } = string.Empty;


    public IEnumerable<ParrillaEventoDto> Eventos { get; set; }
        = new List<ParrillaEventoDto>();


    public IEnumerable<TipoEventoDto> TiposEvento { get; set; }
        = new List<TipoEventoDto>();
}