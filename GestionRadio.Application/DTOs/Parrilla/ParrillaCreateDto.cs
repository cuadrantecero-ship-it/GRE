using System.ComponentModel.DataAnnotations;

namespace GestionRadio.Application.DTOs.Parrilla;

public class ParrillaCreateDto
{
    [Required]
    public long EmisoraId { get; set; }

    [Required]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public bool Activa { get; set; } = true;
}