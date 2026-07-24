using AutoMapper;
using GestionRadio.Application.DTOs;
using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services;

public sealed class ClienteService : IClienteService
{
    private const int UsuarioSistema = 1;

    private readonly IClienteRepository _repository;
    private readonly IMapper _mapper;

    public ClienteService(
        IClienteRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClienteDto>> ObtenerTodosAsync()
    {
        var clientes = await _repository.ObtenerTodosAsync();
        return _mapper.Map<IEnumerable<ClienteDto>>(clientes);
    }

    public async Task<ClienteDto?> ObtenerPorIdAsync(long id)
    {
        var cliente = await _repository.ObtenerPorIdAsync(id);

        if (cliente is null)
            return null;

        return _mapper.Map<ClienteDto>(cliente);
    }

    public async Task<long> CrearAsync(ClienteCreateDto dto)
    {
        var entidad = _mapper.Map<Cliente>(dto);

        entidad.FechaAlta = DateTime.UtcNow;
        entidad.UsuarioAlta = UsuarioSistema;

        if (string.IsNullOrWhiteSpace(entidad.Folio))
        {
            entidad.Folio = Guid.NewGuid()
                .ToString("N")[..12]
                .ToUpper();
        }

        return await _repository.InsertarAsync(entidad);
    }

    public async Task ActualizarAsync(ClienteUpdateDto dto)
    {
        var entidad = await _repository.ObtenerPorIdAsync(dto.IdCliente);

        if (entidad is null)
            throw new Exception("El cliente no existe.");

        entidad.RazonSocial = dto.RazonSocial;
        entidad.NombreComercial = dto.NombreComercial;
        entidad.RFC = dto.RFC;
        entidad.RegimenFiscal = dto.RegimenFiscal;
        entidad.UsoCFDI = dto.UsoCFDI;
        entidad.Contacto = dto.Contacto;
        entidad.Telefono = dto.Telefono;
        entidad.WhatsApp = dto.WhatsApp;
        entidad.Email = dto.Email;
        entidad.Calle = dto.Calle;
        entidad.NumeroExterior = dto.NumeroExterior;
        entidad.NumeroInterior = dto.NumeroInterior;
        entidad.Colonia = dto.Colonia;
        entidad.Ciudad = dto.Ciudad;
        entidad.Estado = dto.Estado;
        entidad.CodigoPostal = dto.CodigoPostal;
        entidad.LimiteCredito = dto.LimiteCredito;
        entidad.DiasCredito = dto.DiasCredito;

        // Auditoría
        entidad.FechaModificacion = DateTime.UtcNow;
        entidad.UsuarioModificacion = UsuarioSistema;

        await _repository.ActualizarAsync(entidad);
    }

    public async Task EliminarAsync(long id)
    {
        var cliente = await _repository.ObtenerPorIdAsync(id);

        if (cliente is null)
            throw new Exception("El cliente no existe.");

        if (!cliente.Activo)
            throw new Exception("El cliente ya se encuentra desactivado.");

        await _repository.CambiarEstadoAsync(id, false);
    }

    public async Task ReactivarAsync(long id)
    {
        var cliente = await _repository.ObtenerPorIdAsync(id);

        if (cliente is null)
            throw new Exception("El cliente no existe.");

        if (cliente.Activo)
            throw new Exception("El cliente ya se encuentra activo.");

        await _repository.CambiarEstadoAsync(id, true);
    }
}