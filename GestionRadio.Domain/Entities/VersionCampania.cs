namespace GestionRadio.Domain.Entities;

public class VersionCampania
{
    public long ID_VERSION { get; set; }

    public long ID_CAMPANIA { get; set; }

    public long MATERIAL_ID_DINESAT { get; set; }

    public string CODIGO_MATERIAL { get; set; } = string.Empty;

    public string TITULO_MATERIAL { get; set; } = string.Empty;

    public int DURACION_SEGUNDOS { get; set; }

    public byte ORDEN_ROTACION { get; set; } = 1;

    public bool PREFERENTE { get; set; }

    public bool ACTIVO { get; set; } = true;

    public DateTime FECHA_ALTA { get; set; }

    public string USUARIO_ALTA { get; set; } = string.Empty;

    public DateTime? FECHA_MODIFICACION { get; set; }

    public string? USUARIO_MODIFICACION { get; set; }
}