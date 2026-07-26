namespace GestionRadio.Application.DTOs.Programacion;

public class ProgramacionDto
{
    public long IdProgramacion { get; set; }

    public long IdCampania { get; set; }

    public long IdVersion { get; set; }

    public long IdEmisora { get; set; }

    public DateOnly FechaProgramacion { get; set; }

    public TimeOnly HoraProgramada { get; set; }

    public long MaterialIdDinesat { get; set; }

    public long? ProgrammingIdDinesat { get; set; }

    public long? ProgramBlockIdDinesat { get; set; }

    public long? ProgramEventIdDinesat { get; set; }

    public string CodigoMaterial { get; set; } = string.Empty;

    public string TituloMaterial { get; set; } = string.Empty;

    public int DuracionSegundos { get; set; }

    public int Orden { get; set; }

    public bool Transmitido { get; set; }

    public bool Activo { get; set; }
}