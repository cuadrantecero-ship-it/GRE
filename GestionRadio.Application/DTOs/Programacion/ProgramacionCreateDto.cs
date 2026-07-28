using System.ComponentModel.DataAnnotations;

namespace GestionRadio.Application.DTOs.Programacion;

public class ProgramacionCreateDto
{
    //=========================================
    // Emisora
    //=========================================

    [Required]
    public long EmisoraId { get; set; }

    //=========================================
    // Parrilla
    //=========================================

    [Required]
    public long ParrillaId { get; set; }

    //=========================================
    // Fecha
    //=========================================

    [Required]
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
    public byte Estado { get; set; } = 1;

    public bool Activa { get; set; } = true;
}