using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services;

public sealed class DinesatPublishService : IDinesatPublishService
{
    private readonly IDinesatPublishRepository _repository;

    public DinesatPublishService(IDinesatPublishRepository repository)
    {
        _repository = repository;
    }

    public async Task PublicarAsync(DateOnly fecha)
    {
        await _repository.PublicarAsync(fecha);
    }
}