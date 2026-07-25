using AutoMapper;
using GestionRadio.Application.DTOs.Programacion;
using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services;

public sealed class ProgramacionService : IProgramacionService
{
    private readonly IProgramacionRepository _repository;
    private readonly IMapper _mapper;

    public ProgramacionService(
        IProgramacionRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProgramacionDto>> ObtenerTodosAsync()
    {
        var datos = await _repository.ObtenerTodosAsync();

        return _mapper.Map<IEnumerable<ProgramacionDto>>(datos);
    }

    public async Task<ProgramacionDto?> ObtenerPorIdAsync(long id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        var entidad = await _repository.ObtenerPorIdAsync(id);

        return entidad == null
            ? null
            : _mapper.Map<ProgramacionDto>(entidad);
    }

    public async Task<long> CrearAsync(ProgramacionCreateDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entidad = _mapper.Map<Programacion>(dto);

        entidad.FechaAlta = DateTime.Now;
        entidad.UsuarioAlta = "ADMIN";
        entidad.Activo = true;

        return await _repository.InsertarAsync(entidad);
    }

    public async Task ActualizarAsync(ProgramacionDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entidad = await _repository.ObtenerPorIdAsync(dto.IdProgramacion);

        if (entidad is null)
            throw new InvalidOperationException("La programación no existe.");

        entidad.FechaProgramacion = dto.FechaProgramacion;
        entidad.HoraProgramada = dto.HoraProgramada;
        entidad.Orden = dto.Orden;
        entidad.Transmitido = dto.Transmitido;
        entidad.Activo = dto.Activo;

        entidad.FechaModificacion = DateTime.Now;
        entidad.UsuarioModificacion = "ADMIN";

        await _repository.ActualizarAsync(entidad);
    }

    public async Task EliminarAsync(long id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        var entidad = await _repository.ObtenerPorIdAsync(id);

        if (entidad is null)
            throw new InvalidOperationException("La programación no existe.");

        await _repository.EliminarLogicoAsync(id);
    }
}