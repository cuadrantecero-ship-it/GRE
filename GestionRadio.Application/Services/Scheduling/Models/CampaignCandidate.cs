namespace GestionRadio.Application.Services.Scheduling.Models;

public sealed class CampaignCandidate
{
    public long ClienteId { get; set; }

    public long CampaniaId { get; set; }

    public string NombreCampania { get; set; } = string.Empty;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public byte Prioridad { get; set; }

    public bool Activa { get; set; }
}