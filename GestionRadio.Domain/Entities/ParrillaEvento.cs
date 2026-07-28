namespace GestionRadio.Domain.Entities;

public class ParrillaEvento
{
    public long EventoId { get; set; }


    public long ParrillaId { get; set; }


    // Relación opcional con bloque origen
    public long? BloqueId { get; set; }


    // SQL Server TIME -> Dapper lo entrega como TimeSpan
    public TimeSpan Hora { get; set; }


    public int TipoEventoId { get; set; }


    public string? Descripcion { get; set; }


    public bool PermitePublicidad { get; set; }


    public int? DuracionMaximaSegundos { get; set; }


    public int Orden { get; set; }



    // Scheduler
    public bool Editable { get; set; }


    public int Prioridad { get; set; }



    // Navegación

    public Parrilla? Parrilla { get; set; }


    public ParrillaBloque? Bloque { get; set; }
}