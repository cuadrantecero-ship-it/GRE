namespace GestionRadio.Domain.Entities;

public class VersionCampania
{
    //==========================================================
    // IDENTIFICACIÓN
    //==========================================================

    public long IdVersion { get; set; }

    public long IdCampania { get; set; }

    //==========================================================
    // DINESAT
    //==========================================================

    public long MaterialIdDinesat { get; set; }

    public string CodigoMaterial { get; set; } = string.Empty;

    public string TituloMaterial { get; set; } = string.Empty;

    public int DuracionSegundos { get; set; }

    //==========================================================
    // PROGRAMACIÓN
    //==========================================================

    public byte OrdenRotacion { get; set; } = 1;

    public bool Preferente { get; set; }

    public bool Activo { get; set; } = true;

    //==========================================================
    // AUDITORÍA
    //==========================================================

    public DateTime FechaAlta { get; set; }

    public string UsuarioAlta { get; set; } = string.Empty;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}