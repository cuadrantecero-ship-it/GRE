namespace GestionRadio.Infrastructure.Dinesat;

public class MaterialDinesat
{
    public long MaterialId { get; set; }

    public string Codigo { get; set; } = string.Empty;

    public string Titulo { get; set; } = string.Empty;

    public int Duracion { get; set; }

    public bool Activo { get; set; }

    public string Categoria { get; set; } = string.Empty;

    public string? TrafficCode { get; set; }
}