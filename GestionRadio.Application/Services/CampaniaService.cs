using AutoMapper;
using GestionRadio.Application.DTOs;
using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services;

public sealed class CampaniaService : ICampaniaService
{
    private const int UsuarioSistema = 1;

    private readonly ICampaniaRepository _repository;
    private readonly IMapper _mapper;

    public CampaniaService(
        ICampaniaRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CampaniaDto>> ObtenerTodosAsync()
    {
        var campanias = await _repository.ObtenerTodosAsync();
        return _mapper.Map<IEnumerable<CampaniaDto>>(campanias);
    }

    public async Task<CampaniaDto?> ObtenerPorIdAsync(long id)
    {
        var campania = await _repository.ObtenerPorIdAsync(id);

        if (campania is null)
            return null;

        return _mapper.Map<CampaniaDto>(campania);
    }

    public async Task CrearAsync(CampaniaCreateDto dto)
    {
        var entidad = _mapper.Map<Campania>(dto);

        entidad.FechaAlta = DateTime.UtcNow;
        entidad.UsuarioAlta = UsuarioSistema;
        entidad.Activo = true;
        entidad.Estado = "ACTIVA";

        if (string.IsNullOrWhiteSpace(entidad.Folio))
        {
            entidad.Folio = Guid.NewGuid()
                .ToString("N")[..12]
                .ToUpper();
        }

        await _repository.InsertarAsync(entidad);
    }

    public async Task ActualizarAsync(CampaniaUpdateDto dto)
    {
        var entidad = await _repository.ObtenerPorIdAsync(dto.IdCampania);

        if (entidad is null)
            throw new Exception("La campaña no existe.");

        entidad.IdCliente = dto.IdCliente;
        entidad.Nombre = dto.Nombre;
        entidad.Descripcion = dto.Descripcion;
        entidad.FechaInicio = dto.FechaInicio;
        entidad.FechaFin = dto.FechaFin;
        entidad.Prioridad = dto.Prioridad;
        entidad.Estado = dto.Estado;

        entidad.FechaModificacion = DateTime.UtcNow;
        entidad.UsuarioModificacion = UsuarioSistema;

        await _repository.ActualizarAsync(entidad);
    }

    public async Task EliminarAsync(long id)
    {
        var campania = await _repository.ObtenerPorIdAsync(id);

        if (campania is null)
            throw new Exception("La campaña no existe.");

        if (!campania.Activo)
            throw new Exception("La campaña ya se encuentra desactivada.");

        await _repository.EliminarLogicoAsync(id);
    }
}