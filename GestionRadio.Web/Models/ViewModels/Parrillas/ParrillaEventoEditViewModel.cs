using GestionRadio.Application.DTOs.Parrilla;

namespace GestionRadio.Web.Models.ViewModels.Parrillas;

public class ParrillaEventoEditViewModel
{
    public long ParrillaId { get; set; }


    public string NombreParrilla { get; set; }
        = string.Empty;


    public ParrillaEventoDto Evento { get; set; }
        = new ParrillaEventoDto();


    public IEnumerable<TipoEventoDto> TiposEvento { get; set; }
        = new List<TipoEventoDto>();
}