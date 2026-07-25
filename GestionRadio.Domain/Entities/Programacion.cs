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
    // Fecha
    //=========================================

    public DateOnly FechaProgramacion { get; set; }

    //=========================================
    // Horario
    //=========================================

    public TimeOnly HoraProgramada { get; set; }

    //=========================================
    // Información del material
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