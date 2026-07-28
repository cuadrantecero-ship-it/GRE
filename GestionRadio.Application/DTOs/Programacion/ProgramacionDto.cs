namespace GestionRadio.Application.DTOs.Programacion;

public class ProgramacionDto
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
    // Dinesat
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
    public byte Estado { get; set; }

    public bool Activa { get; set; }
}