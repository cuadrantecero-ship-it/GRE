using GestionRadio.Domain.Entities;

namespace GestionRadio.Domain.Interfaces;

public interface ICampaniaRepository
{
    Task<IEnumerable<Campania>> ObtenerTodosAsync();

    Task<Campania?> ObtenerPorIdAsync(long id);

    Task<long> InsertarAsync(Campania campania);

    Task ActualizarAsync(Campania campania);

    Task EliminarLogicoAsync(long id);

    Task<bool> ExisteFolioAsync(string folio);

    // Scheduler
    Task<IEnumerable<Campania>> ObtenerCampaniasElegiblesAsync(DateOnly fecha);
}