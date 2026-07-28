namespace GestionRadio.Application.DTOs.Parrilla;

public class ParrillaEventoDto
{
    public long EventoId { get; set; }


    public long ParrillaId { get; set; }


    // SQL TIME -> TimeSpan
    public TimeSpan Hora { get; set; }


    public int TipoEventoId { get; set; }


    public string? Descripcion { get; set; }


    public bool PermitePublicidad { get; set; }


    public int? DuracionMaximaSegundos { get; set; }


    public int Orden { get; set; }
}