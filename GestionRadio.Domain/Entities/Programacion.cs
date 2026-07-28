namespace GestionRadio.Domain.Entities;

public class Programacion
{
    //=========================================
    // Identificación
    //=========================================

    public long ProgramacionId { get; set; }

    //=========================================
    // Emisora
    //=========================================

    public long EmisoraId { get; set; }

    //=========================================
    // Parrilla
    //=========================================

    public long ParrillaId { get; set; }

    //=========================================
    // Fecha
    //=========================================

    public DateOnly Fecha { get; set; }

    //=========================================
    // Referencia Dinesat
    //=========================================

    public long? DinesatProgrammingId { get; set; }

    //=========================================
    // Estado
    //=========================================

    /// <summary>
    /// 1 = Borrador
    /// 2 = Generada
    /// 3 = Sincronizada
    /// 4 = Publicada
    /// </summary>
    public byte Estado { get; set; } = 1;

    public bool Activa { get; set; } = true;

    //=========================================
    // Auditoría
    //=========================================

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = string.Empty;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    //=========================================
    // Navegación
    //=========================================

    public ICollection<ProgramacionDetalle> Detalles { get; set; }
        = new List<ProgramacionDetalle>();
}