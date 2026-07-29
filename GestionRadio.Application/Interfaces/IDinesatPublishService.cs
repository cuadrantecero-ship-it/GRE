namespace GestionRadio.Application.Interfaces;

public interface IDinesatPublishService
{
    Task PublicarProgramacionAsync(long programacionId);
}