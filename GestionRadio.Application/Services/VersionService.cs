using AutoMapper;
using GestionRadio.Application.DTOs.Versiones;
using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services;

public sealed class VersionService : IVersionService
{
    private const string UsuarioSistema = "ADMIN";

    private readonly IVersionRepository _repository;
    private readonly IMapper _mapper;

    public VersionService(
        IVersionRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VersionDto>> ObtenerTodosAsync()
    {
        var versiones = await _repository.ObtenerTodosAsync();
        return _mapper.Map<IEnumerable<VersionDto>>(versiones);
    }

    public async Task<VersionDto?> ObtenerPorIdAsync(long id)
    {
        var version = await _repository.ObtenerPorIdAsync(id);

        if (version is null)
            return null;

        return _mapper.Map<VersionDto>(version);
    }

    public async Task CrearAsync(VersionCreateDto dto)
    {
        var entidad = _mapper.Map<VersionCampania>(dto);

        entidad.FechaAlta = DateTime.UtcNow;
        entidad.UsuarioAlta = UsuarioSistema;
        entidad.Activo = true;

        await _repository.InsertarAsync(entidad);
    }

    public async Task ActualizarAsync(VersionUpdateDto dto)
    {
        var entidad = await _repository.ObtenerPorIdAsync(dto.IdVersion);

        if (entidad is null)
            throw new Exception("La versión no existe.");

        entidad.OrdenRotacion = (byte)dto.OrdenRotacion;
        entidad.Preferente = dto.Preferente;
        entidad.Activo = dto.Activo;

        entidad.FechaModificacion = DateTime.UtcNow;
        entidad.UsuarioModificacion = UsuarioSistema;

        await _repository.ActualizarAsync(entidad);
    }

    public async Task EliminarAsync(long id)
    {
        var version = await _repository.ObtenerPorIdAsync(id);

        if (version is null)
            throw new Exception("La versión no existe.");

        if (!version.Activo)
            throw new Exception("La versión ya está desactivada.");

        await _repository.EliminarLogicoAsync(id);
    }
}