using AutoMapper;
using GestionRadio.Application.DTOs;
using GestionRadio.Application.DTOs.Parrillas;
using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services;

public sealed class ParrillaService : IParrillaService
{
    private readonly IParrillaRepository _repository;
    private readonly IMapper _mapper;

    public ParrillaService(
        IParrillaRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    #region Parrillas

    public async Task<IEnumerable<ParrillaDto>> ObtenerTodasAsync()
    {
        var lista = await _repository.ObtenerTodasAsync();

        return _mapper.Map<IEnumerable<ParrillaDto>>(lista);
    }

    public async Task<ParrillaDto?> ObtenerPorIdAsync(long id)
    {
        var entidad = await _repository.ObtenerPorIdAsync(id);

        if (entidad == null)
            return null;

        return _mapper.Map<ParrillaDto>(entidad);
    }

    public async Task<long> CrearAsync(ParrillaCreateDto dto)
    {
        var entidad = _mapper.Map<Parrilla>(dto);

        entidad.FechaCreacion = DateTime.UtcNow;
        entidad.Activa = true;

        return await _repository.InsertarAsync(entidad);
    }

    public async Task ActualizarAsync(ParrillaUpdateDto dto)
    {
        var entidad = await _repository.ObtenerPorIdAsync(dto.ParrillaId);

        if (entidad == null)
            throw new Exception("La parrilla no existe.");

        entidad.Nombre = dto.Nombre;
        entidad.EmisoraId = dto.EmisoraId;
        entidad.FechaInicio = dto.FechaInicio;
        entidad.FechaFin = dto.FechaFin;
        entidad.Activa = dto.Activa;

        await _repository.ActualizarAsync(entidad);
    }

    public async Task EliminarAsync(long id)
    {
        var entidad = await _repository.ObtenerPorIdAsync(id);

        if (entidad == null)
            throw new Exception("La parrilla no existe.");

        await _repository.EliminarAsync(id);
    }

    #endregion

    #region Eventos

    public async Task<IEnumerable<ParrillaEventoDto>> ObtenerEventosAsync(long parrillaId)
    {
        var lista = await _repository.ObtenerEventosAsync(parrillaId);

        return _mapper.Map<IEnumerable<ParrillaEventoDto>>(lista);
    }

    public async Task GuardarEventosAsync(
        long parrillaId,
        IEnumerable<ParrillaEventoUpdateDto> eventos)
    {
        var entidades = _mapper.Map<IEnumerable<ParrillaEvento>>(eventos);

        await _repository.GuardarEventosAsync(
            parrillaId,
            entidades);
    }

    public async Task<IEnumerable<TipoEventoDto>> ObtenerTiposEventoAsync()
    {
        var lista = await _repository.ObtenerTiposEventoAsync();

        return _mapper.Map<IEnumerable<TipoEventoDto>>(lista);
    }

    #endregion
}