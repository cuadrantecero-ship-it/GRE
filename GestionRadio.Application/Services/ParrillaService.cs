using AutoMapper;
using GestionRadio.Application.DTOs;
using GestionRadio.Application.DTOs.Parrilla;
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



    //==================================================
    // PARRILLAS
    //==================================================

    public async Task<IEnumerable<ParrillaDto>> ObtenerTodasAsync()
    {
        var lista =
            await _repository.ObtenerTodasAsync();

        return _mapper.Map<IEnumerable<ParrillaDto>>(lista);
    }



    public async Task<ParrillaDto?> ObtenerPorIdAsync(
        long id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));


        var entidad =
            await _repository.ObtenerPorIdAsync(id);


        return entidad == null
            ? null
            : _mapper.Map<ParrillaDto>(entidad);
    }



    public async Task<long> CrearAsync(
        ParrillaCreateDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);


        var entidad =
            _mapper.Map<Parrilla>(dto);


        entidad.FechaCreacion =
            DateTime.Now;

        entidad.Activa = true;


        return await _repository.InsertarAsync(entidad);
    }



    public async Task ActualizarAsync(
        ParrillaUpdateDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);


        var entidad =
            await _repository.ObtenerPorIdAsync(
                dto.ParrillaId);


        if (entidad == null)
            throw new InvalidOperationException(
                "La parrilla no existe.");


        entidad.Nombre = dto.Nombre;

        entidad.EmisoraId =
            dto.EmisoraId;

        entidad.FechaInicio =
            dto.FechaInicio;

        entidad.FechaFin =
            dto.FechaFin;

        entidad.Activa =
            dto.Activa;


        await _repository.ActualizarAsync(entidad);
    }



    public async Task EliminarAsync(
        long id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));


        var entidad =
            await _repository.ObtenerPorIdAsync(id);


        if (entidad == null)
            throw new InvalidOperationException(
                "La parrilla no existe.");


        await _repository.EliminarAsync(id);
    }



    //==================================================
    // EVENTOS DE PARRILLA
    //==================================================

    public async Task<IEnumerable<ParrillaEventoDto>> ObtenerEventosAsync(
        long parrillaId)
    {
        if (parrillaId <= 0)
            throw new ArgumentOutOfRangeException(nameof(parrillaId));


        var lista =
            await _repository.ObtenerEventosAsync(parrillaId);


        return _mapper.Map<IEnumerable<ParrillaEventoDto>>(lista);
    }



    public async Task GuardarEventosAsync(
        long parrillaId,
        IEnumerable<ParrillaEventoUpdateDto> eventos)
    {
        ArgumentNullException.ThrowIfNull(eventos);


        var entidades =
            _mapper.Map<IEnumerable<ParrillaEvento>>(eventos);


        await _repository.GuardarEventosAsync(
            parrillaId,
            entidades);
    }



    public async Task<IEnumerable<TipoEventoDto>> ObtenerTiposEventoAsync()
    {
        var lista =
            await _repository.ObtenerTiposEventoAsync();


        return _mapper.Map<IEnumerable<TipoEventoDto>>(lista);
    }
    
    //==================================================
    // CRUD EVENTOS
    //==================================================

    public async Task CrearEventoAsync(
        long parrillaId,
        ParrillaEventoCreateDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);


        if (parrillaId <= 0)
            throw new ArgumentOutOfRangeException(nameof(parrillaId));


        var entidad =
            _mapper.Map<ParrillaEvento>(dto);


        entidad.ParrillaId = parrillaId;


        await _repository.InsertarEventoAsync(entidad);
    }


    public async Task ActualizarEventoAsync(
        ParrillaEventoUpdateDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);


        var entidad =
            _mapper.Map<ParrillaEvento>(dto);


        await _repository.ActualizarEventoAsync(entidad);
    }


    public async Task EliminarEventoAsync(
        long eventoId)
    {
        if (eventoId <= 0)
            throw new ArgumentOutOfRangeException(nameof(eventoId));


        await _repository.EliminarEventoAsync(eventoId);
    }
}
