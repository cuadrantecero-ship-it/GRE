using System.ComponentModel.DataAnnotations;

namespace GestionRadio.Application.DTOs;

public class CampaniaUpdateDto
{
    [Required]
    public long IdCampania { get; set; }

    [Required]
    [StringLength(200)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Descripcion { get; set; }

    [Required]
    public long IdCliente { get; set; }

    [Required]
    public DateOnly FechaInicio { get; set; }

    [Required]
    public DateOnly FechaFin { get; set; }

    [Range(1, 4)]
    public byte Prioridad { get; set; }

    [Required]
    [StringLength(20)]
    public string Estado { get; set; } = string.Empty;

    public bool Activo { get; set; }
}