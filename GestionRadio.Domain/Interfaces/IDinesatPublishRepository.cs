namespace GestionRadio.Domain.Interfaces;

public interface IDinesatPublishRepository
{
    Task PublicarProgramacionAsync(long programacionId);
}