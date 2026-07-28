using AutoMapper;
using GestionRadio.Application.DTOs.Programacion;
using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services;

public sealed class ProgramacionService : IProgramacionService
{
    private readonly IProgramacionRepository _repository;
    private readonly IProgramacionDetalleRepository _detalleRepository;
    private readonly IMapper _mapper;

    public ProgramacionService(
        IProgramacionRepository repository,
        IProgramacionDetalleRepository detalleRepository,
        IMapper mapper)
    {
        _repository = repository;
        _detalleRepository = detalleRepository;
        _mapper = mapper;
    }


    //==================================================
    // CABECERA
    //==================================================

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

        entidad.FechaCreacion = DateTime.Now;
        entidad.UsuarioCreacion = "ADMIN";
        entidad.Activa = true;
        entidad.Estado = 1;

        return await _repository.InsertarAsync(entidad);
    }


    public async Task ActualizarAsync(ProgramacionDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entidad =
            await _repository.ObtenerPorIdAsync(dto.ProgramacionId);

        if (entidad is null)
            throw new InvalidOperationException(
                "La programación no existe.");

        entidad.Fecha = dto.Fecha;
        entidad.EmisoraId = dto.EmisoraId;
        entidad.ParrillaId = dto.ParrillaId;
        entidad.Estado = dto.Estado;

        entidad.FechaModificacion = DateTime.Now;
        entidad.UsuarioModificacion = "ADMIN";

        await _repository.ActualizarAsync(entidad);
    }


    public async Task EliminarAsync(long id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        var entidad =
            await _repository.ObtenerPorIdAsync(id);

        if (entidad is null)
            throw new InvalidOperationException(
                "La programación no existe.");

        await _repository.EliminarLogicoAsync(id);
    }


    //==================================================
    // DETALLES
    //==================================================

    public async Task<IEnumerable<ProgramacionDetalleDto>> ObtenerDetallesAsync(
        long programacionId)
    {
        if (programacionId <= 0)
            throw new ArgumentOutOfRangeException(nameof(programacionId));

        var detalles =
            await _detalleRepository.ObtenerPorProgramacionAsync(programacionId);

        return _mapper.Map<IEnumerable<ProgramacionDetalleDto>>(detalles);
    }


    public async Task<long> AgregarDetalleAsync(
        ProgramacionDetalleCreateDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var detalle =
            _mapper.Map<ProgramacionDetalle>(dto);

        detalle.Transmitido = false;
        detalle.Sincronizado = false;
        detalle.Activo = true;

        detalle.FechaCreacion = DateTime.Now;
        detalle.UsuarioCreacion = "ADMIN";

        return await _detalleRepository.InsertarAsync(detalle);
    }


    public async Task ActualizarDetalleAsync(
        ProgramacionDetalleDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var detalle =
            await _detalleRepository.ObtenerPorIdAsync(
                dto.ProgramacionDetalleId);

        if (detalle is null)
            throw new InvalidOperationException(
                "El detalle de programación no existe.");

        detalle.BloqueId = dto.BloqueId;
        detalle.Hora = dto.Hora;
        detalle.Orden = dto.Orden;

        detalle.FechaModificacion = DateTime.Now;
        detalle.UsuarioModificacion = "ADMIN";

        await _detalleRepository.ActualizarAsync(detalle);
    }


    public async Task EliminarDetalleAsync(
        long programacionDetalleId)
    {
        if (programacionDetalleId <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(programacionDetalleId));

        await _detalleRepository.EliminarLogicoAsync(
            programacionDetalleId);
    }
}