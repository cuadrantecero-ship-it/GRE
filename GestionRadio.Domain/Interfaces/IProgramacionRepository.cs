using GestionRadio.Domain.Entities;

namespace GestionRadio.Domain.Interfaces;

public interface IProgramacionRepository
{
    Task<IEnumerable<Programacion>> ObtenerTodosAsync();

    Task<Programacion?> ObtenerPorIdAsync(long id);

    Task<long> InsertarAsync(Programacion programacion);

    Task ActualizarAsync(Programacion programacion);

    Task EliminarLogicoAsync(long id);
}