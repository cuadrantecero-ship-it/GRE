namespace GestionRadio.Application.DTOs.Programacion;

public class ProgramacionDetalleDto
{
    public long ProgramacionDetalleId { get; set; }

    public long ProgramacionId { get; set; }

    public long ClienteId { get; set; }

    public long CampaniaId { get; set; }

    public long VersionId { get; set; }

    //==================================================
    // EVENTO DE PARRILLA
    //==================================================

    public long EventoParrillaId { get; set; }

    public TimeOnly Hora { get; set; }

    public int Orden { get; set; }

    //==================================================
    // DINESAT
    //==================================================

    public long? DinesatProgramBlockId { get; set; }

    public long? DinesatProgramEventId { get; set; }

    public long? DinesatMaterialId { get; set; }

    //==================================================
    // MATERIAL
    //==================================================

    public string? CodigoMaterial { get; set; }

    public string? TituloMaterial { get; set; }

    public int DuracionSegundos { get; set; }

    //==================================================
    // ESTADO
    //==================================================

    public bool Transmitido { get; set; }

    public bool Sincronizado { get; set; }

    public bool Activo { get; set; }
}