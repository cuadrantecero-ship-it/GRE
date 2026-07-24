using GestionRadio.Domain.Entities;

namespace GestionRadio.Domain.Interfaces;

public interface IVersionRepository
{
    Task<IEnumerable<VersionCampania>> ObtenerTodosAsync();

    Task<VersionCampania?> ObtenerPorIdAsync(long id);

    Task<long> InsertarAsync(VersionCampania version);

    Task ActualizarAsync(VersionCampania version);

    Task EliminarLogicoAsync(long id);
}