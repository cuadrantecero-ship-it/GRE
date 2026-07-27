using System.Threading.Tasks;

namespace GestionRadio.Application.Interfaces;

public interface IDinesatPublishService
{
    Task PublicarAsync(DateOnly fecha);
}