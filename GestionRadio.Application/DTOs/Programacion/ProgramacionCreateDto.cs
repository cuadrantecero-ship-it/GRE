using System.ComponentModel.DataAnnotations;

namespace GestionRadio.Application.DTOs.Programacion;

public class ProgramacionCreateDto
{
    [Required]
    public long IdCampania { get; set; }

    [Required]
    public long IdVersion { get; set; }

    [Required]
    public long IdEmisora { get; set; }

    [Required]
    public DateOnly FechaProgramacion { get; set; }

    [Required]
    public TimeOnly HoraProgramada { get; set; }

    [Required]
    public long MaterialIdDinesat { get; set; }

    [Required]
    public string CodigoMaterial { get; set; } = string.Empty;

    [Required]
    public string TituloMaterial { get; set; } = string.Empty;

    [Range(1, 3600)]
    public int DuracionSegundos { get; set; }

    public int Orden { get; set; }

    public bool Transmitido { get; set; }

    public bool Activo { get; set; } = true;

    public long? ProgrammingIdDinesat { get; set; }

    public long? ProgramBlockIdDinesat { get; set; }

    public long? ProgramEventIdDinesat { get; set; }
}