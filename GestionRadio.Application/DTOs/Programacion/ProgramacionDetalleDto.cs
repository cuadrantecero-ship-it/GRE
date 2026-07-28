namespace GestionRadio.Application.DTOs.Programacion;

public class ProgramacionDetalleDto
{
    public long ProgramacionDetalleId { get; set; }

    public long ProgramacionId { get; set; }

    public long ClienteId { get; set; }

    public long CampaniaId { get; set; }

    public long VersionId { get; set; }

    public long BloqueId { get; set; }

    public TimeOnly Hora { get; set; }

    public int Orden { get; set; }

    public long? DinesatProgramBlockId { get; set; }

    public long? DinesatProgramEventId { get; set; }

    public long? DinesatMaterialId { get; set; }

    public string? CodigoMaterial { get; set; }

    public string? TituloMaterial { get; set; }

    public int DuracionSegundos { get; set; }

    public bool Transmitido { get; set; }

    public bool Sincronizado { get; set; }

    public bool Activo { get; set; }
}