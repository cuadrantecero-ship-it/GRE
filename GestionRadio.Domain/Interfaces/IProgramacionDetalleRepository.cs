using GestionRadio.Domain.Entities;

namespace GestionRadio.Domain.Interfaces;

public interface IProgramacionDetalleRepository
{
    Task<IEnumerable<ProgramacionDetalle>> ObtenerPorProgramacionAsync(long programacionId);

    Task<ProgramacionDetalle?> ObtenerPorIdAsync(long programacionDetalleId);

    Task<long> InsertarAsync(ProgramacionDetalle detalle);

    Task ActualizarAsync(ProgramacionDetalle detalle);

    Task EliminarLogicoAsync(long programacionDetalleId);
}