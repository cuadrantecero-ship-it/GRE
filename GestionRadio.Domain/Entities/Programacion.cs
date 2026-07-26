namespace GestionRadio.Domain.Entities;

public class Programacion
{
    //=========================================
    // Identificación
    //=========================================

    public long IdProgramacion { get; set; }

    public long IdCampania { get; set; }

    public long IdVersion { get; set; }


    //=========================================
    // Emisora
    //=========================================

    public long IdEmisora { get; set; }


    //=========================================
    // Fecha y hora
    //=========================================

    public DateOnly FechaProgramacion { get; set; }

    public TimeOnly HoraProgramada { get; set; }


    //=========================================
    // Referencias Dinesat
    //=========================================

    public long? ProgrammingIdDinesat { get; set; }

    public long? ProgramBlockIdDinesat { get; set; }

    public long? ProgramEventIdDinesat { get; set; }


    //=========================================
    // Material Dinesat
    //=========================================

    public long MaterialIdDinesat { get; set; }

    public string CodigoMaterial { get; set; } = string.Empty;

    public string TituloMaterial { get; set; } = string.Empty;

    public int DuracionSegundos { get; set; }


    //=========================================
    // Orden
    //=========================================

    public int Orden { get; set; }


    //=========================================
    // Estado
    //=========================================

    public bool Transmitido { get; set; }

    public bool Activo { get; set; } = true;


    //=========================================
    // Auditoría
    //=========================================

    public DateTime FechaAlta { get; set; }

    public string UsuarioAlta { get; set; } = string.Empty;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}