using System.ComponentModel.DataAnnotations;

namespace GestionRadio.Application.DTOs.Programacion;

public class ProgramacionDetalleCreateDto
{
    //=========================================
    // Programación
    //=========================================

    [Required]
    public long ProgramacionId { get; set; }

    //=========================================
    // Cliente
    //=========================================

    [Required]
    public long ClienteId { get; set; }

    //=========================================
    // Campaña
    //=========================================

    [Required]
    public long CampaniaId { get; set; }

    //=========================================
    // Versión
    //=========================================

    [Required]
    public long VersionId { get; set; }

    //=========================================
    // Bloque
    //=========================================

    [Required]
    public long BloqueId { get; set; }

    //=========================================
    // Hora
    //=========================================

    [Required]
    public TimeOnly Hora { get; set; }

    //=========================================
    // Orden
    //=========================================

    public int Orden { get; set; }

    //=========================================
    // Estado
    //=========================================

    public bool Activo { get; set; } = true;
}