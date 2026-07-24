namespace GestionRadio.Application.DTOs;

public class CampaniaDto
{
    public long IdCampania { get; set; }

    public string Folio { get; set; } = string.Empty;

    public long IdCliente { get; set; }

    // NUEVO
    public string Cliente { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public byte Prioridad { get; set; }

    public string Estado { get; set; } = string.Empty;

    public bool Activo { get; set; }

    public DateTime FechaAlta { get; set; }
}