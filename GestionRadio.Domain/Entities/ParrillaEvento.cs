namespace GestionRadio.Domain.Entities;

public class ParrillaEvento
{
    //==================================================
    // IDENTIFICACIÓN
    //==================================================

    public long EventoId { get; set; }

    public long ParrillaId { get; set; }

    //==================================================
    // PROGRAMACIÓN
    //==================================================

    /// <summary>
    /// SQL Server TIME (Dapper lo mapea como TimeSpan).
    /// </summary>
    public TimeSpan Hora { get; set; }

    public int TipoEventoId { get; set; }

    public string? Descripcion { get; set; }

    public bool PermitePublicidad { get; set; }

    public int? DuracionMaximaSegundos { get; set; }

    public int Orden { get; set; }

    //==================================================
    // SCHEDULER
    //==================================================

    public bool Editable { get; set; }

    public int Prioridad { get; set; }

    //==================================================
    // NAVEGACIÓN
    //==================================================

    public Parrilla? Parrilla { get; set; }
}