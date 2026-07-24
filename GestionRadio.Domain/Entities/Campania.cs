namespace GestionRadio.Domain.Entities;

public class Campania
{
    public long IdCampania { get; set; }

    public string Folio { get; set; } = string.Empty;

    public long IdCliente { get; set; }

    // NUEVO: Razón social del cliente (JOIN con GR_CLIENTE)
    public string Cliente { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public byte Prioridad { get; set; }

    public string Estado { get; set; } = string.Empty;

    public bool Activo { get; set; }

    public DateTime FechaAlta { get; set; }

    public long UsuarioAlta { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public long? UsuarioModificacion { get; set; }
}