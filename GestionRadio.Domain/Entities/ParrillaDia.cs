namespace GestionRadio.Domain.Entities;

public class ParrillaDia
{
    public long ParrillaDiaId { get; set; }

    public long ParrillaId { get; set; }

    public byte DiaSemana { get; set; }
}