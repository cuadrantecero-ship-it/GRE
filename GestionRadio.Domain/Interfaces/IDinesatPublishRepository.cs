using System.Threading.Tasks;

namespace GestionRadio.Domain.Interfaces;

public interface IDinesatPublishRepository
{
    Task PublicarAsync(DateOnly fecha);
}