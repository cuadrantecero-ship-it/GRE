using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Sql;

namespace GestionRadio.Infrastructure.Repositories;

public sealed class CampaniaRepository : BaseRepository, ICampaniaRepository
{
    public CampaniaRepository(SqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<Campania>> ObtenerTodosAsync()
    {
        using var db = CreateConnection();

        return await db.QueryAsync<Campania>(
            CampaniasSql.ObtenerTodos);
    }

    public async Task<Campania?> ObtenerPorIdAsync(long id)
    {
        using var db = CreateConnection();

        return await db.QueryFirstOrDefaultAsync<Campania>(
            CampaniasSql.ObtenerPorId,
            new
            {
                IdCampania = id
            });
    }

    public async Task<long> InsertarAsync(Campania campania)
    {
        using var db = CreateConnection();

        return await db.ExecuteScalarAsync<long>(
            CampaniasSql.Insertar,
            campania);
    }

    public async Task ActualizarAsync(Campania campania)
    {
        using var db = CreateConnection();

        await db.ExecuteAsync(
            CampaniasSql.Actualizar,
            campania);
    }

    public async Task EliminarLogicoAsync(long id)
    {
        using var db = CreateConnection();

        var filas = await db.ExecuteAsync(
            CampaniasSql.EliminarLogico,
            new
            {
                IdCampania = id,
                FechaModificacion = DateTime.UtcNow,
                UsuarioModificacion = 1
            });

        if (filas != 1)
            throw new Exception($"Se esperaban 1 fila afectada y se afectaron {filas}.");
    }

    public async Task<bool> ExisteFolioAsync(string folio)
    {
        using var db = CreateConnection();

        var total = await db.ExecuteScalarAsync<int>(
            CampaniasSql.ExisteFolio,
            new
            {
                Folio = folio
            });

        return total > 0;
    }

    public async Task<IEnumerable<Campania>> ObtenerCampaniasElegiblesAsync(DateOnly fecha)
    {
        using var db = CreateConnection();

        return await db.QueryAsync<Campania>(
            CampaniasSql.ObtenerCampaniasElegibles,
            new
            {
                Fecha = fecha
            });
    }
}