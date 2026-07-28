namespace GestionRadio.Domain.Entities;

public sealed class Emisora
{
    public long EmisoraId { get; set; }

    public string Siglas { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public long DinesatStationId { get; set; }

    public bool Activa { get; set; }

    public DateTime FechaAlta { get; set; }

    public string UsuarioAlta { get; set; } = string.Empty;
}