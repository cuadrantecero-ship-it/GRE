namespace GestionRadio.Domain.Entities;

public class ProgramacionDetalle
{
    //==========================================================
    // IDENTIFICACIÓN
    //==========================================================

    public long ProgramacionDetalleId { get; set; }

    public long ProgramacionId { get; set; }

    //==========================================================
    // NEGOCIO
    //==========================================================

    public long ClienteId { get; set; }

    public long CampaniaId { get; set; }

    public long VersionId { get; set; }

    //==========================================================
    // PARRILLA
    //==========================================================

    public long EventoParrillaId { get; set; }

    public int Orden { get; set; }

    public TimeOnly Hora { get; set; }

    //==========================================================
    // DINESAT
    //==========================================================

    public long? DinesatProgramBlockId { get; set; }

    public long? DinesatProgramEventId { get; set; }

    public long? DinesatMaterialId { get; set; }

    //==========================================================
    // MATERIAL
    //==========================================================

    public string CodigoMaterial { get; set; } = string.Empty;

    public string TituloMaterial { get; set; } = string.Empty;

    public int DuracionSegundos { get; set; }

    //==========================================================
    // ESTADO
    //==========================================================

    public byte Estado { get; set; } = 1;

    public bool Sincronizado { get; set; }

    public bool Transmitido { get; set; }

    public bool Activo { get; set; } = true;

    //==========================================================
    // AUDITORÍA
    //==========================================================

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = string.Empty;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    //==========================================================
    // NAVEGACIÓN
    //==========================================================

    public Programacion? Programacion { get; set; }
}