namespace GestionRadio.Domain.Entities;

public class ProgramacionDetalle
{
    //=========================================
    // Identificación
    //=========================================

    public long ProgramacionDetalleId { get; set; }

    public long ProgramacionId { get; set; }

    //=========================================
    // Referencias de negocio
    //=========================================

    public long ClienteId { get; set; }

    public long CampaniaId { get; set; }

    public long VersionId { get; set; }

    //=========================================
    // Parrilla
    //=========================================

    public long BloqueId { get; set; }

    public int Orden { get; set; }

    public TimeOnly Hora { get; set; }

    //=========================================
    // Referencias Dinesat
    //=========================================

    public long? DinesatProgramBlockId { get; set; }

    public long? DinesatProgramEventId { get; set; }

    public long? DinesatMaterialId { get; set; }

    //=========================================
    // Material
    //=========================================

    public string CodigoMaterial { get; set; } = string.Empty;

    public string TituloMaterial { get; set; } = string.Empty;

    public int DuracionSegundos { get; set; }

    //=========================================
    // Estado
    //=========================================

    public bool Transmitido { get; set; }

    public bool Sincronizado { get; set; }

    public bool Activo { get; set; } = true;

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

    public Programacion? Programacion { get; set; }

    public ParrillaBloque? Bloque { get; set; }
}