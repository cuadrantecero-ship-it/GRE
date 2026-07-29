using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services;

public sealed class ProgramacionDetalleService
    : IProgramacionDetalleService
{
    private readonly IProgramacionDetalleRepository _repository;

    public ProgramacionDetalleService(
        IProgramacionDetalleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProgramacionDetalle>> ObtenerPorProgramacionAsync(
        long programacionId)
    {
        return await _repository.ObtenerPorProgramacionAsync(programacionId);
    }

    public async Task<ProgramacionDetalle?> ObtenerPorIdAsync(
        long programacionDetalleId)
    {
        return await _repository.ObtenerPorIdAsync(programacionDetalleId);
    }

    public async Task<long> CrearAsync(
        ProgramacionDetalle detalle)
    {
        ArgumentNullException.ThrowIfNull(detalle);

        detalle.Estado = 1;
        detalle.Activo = true;
        detalle.Sincronizado = false;
        detalle.Transmitido = false;

        if (detalle.FechaCreacion == default)
            detalle.FechaCreacion = DateTime.Now;

        if (string.IsNullOrWhiteSpace(detalle.UsuarioCreacion))
            detalle.UsuarioCreacion = "AUTO-SCHEDULER";

        return await _repository.InsertarAsync(detalle);
    }

    public async Task ActualizarAsync(
        ProgramacionDetalle detalle)
    {
        ArgumentNullException.ThrowIfNull(detalle);

        detalle.FechaModificacion = DateTime.Now;

        await _repository.ActualizarAsync(detalle);
    }

    public async Task EliminarAsync(
        long programacionDetalleId)
    {
        await _repository.EliminarLogicoAsync(programacionDetalleId);
    }
}