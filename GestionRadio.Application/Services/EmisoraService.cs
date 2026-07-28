using AutoMapper;
using GestionRadio.Application.DTOs.Emisora;
using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services;

public sealed class EmisoraService : IEmisoraService
{
    private readonly IEmisoraRepository _repository;
    private readonly IMapper _mapper;


    public EmisoraService(
        IEmisoraRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<IEnumerable<EmisoraDto>> ObtenerActivasAsync()
    {
        var datos = await _repository.ObtenerActivasAsync();

        return _mapper.Map<IEnumerable<EmisoraDto>>(datos);
    }


    public async Task<IEnumerable<EmisoraDto>> ObtenerTodasAsync()
    {
        var datos = await _repository.ObtenerTodasAsync();

        return _mapper.Map<IEnumerable<EmisoraDto>>(datos);
    }


    public async Task<EmisoraDto?> ObtenerPorIdAsync(long id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));


        var entidad = await _repository.ObtenerPorIdAsync(id);


        return entidad == null
            ? null
            : _mapper.Map<EmisoraDto>(entidad);
    }
}