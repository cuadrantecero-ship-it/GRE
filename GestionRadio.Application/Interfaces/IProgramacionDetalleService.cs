using GestionRadio.Domain.Entities;

namespace GestionRadio.Application.Interfaces;

public interface IProgramacionDetalleService
{
    Task<IEnumerable<ProgramacionDetalle>> ObtenerPorProgramacionAsync(long programacionId);

    Task<ProgramacionDetalle?> ObtenerPorIdAsync(long programacionDetalleId);

    Task<long> CrearAsync(ProgramacionDetalle detalle);

    Task ActualizarAsync(ProgramacionDetalle detalle);

    Task EliminarAsync(long programacionDetalleId);
}