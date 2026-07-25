using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Sql;

namespace GestionRadio.Infrastructure.Repositories;

public sealed class VersionRepository : BaseRepository, IVersionRepository
{
    public VersionRepository(SqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }


    public async Task<IEnumerable<VersionCampania>> ObtenerPorCampaniaAsync(long campaniaId)
    {
        using var db = CreateConnection();

        return await db.QueryAsync<VersionCampania>(
            VersionesSql.ObtenerPorCampania,
            new
            {
                IdCampania = campaniaId
            });
    }
    public async Task<IEnumerable<VersionCampania>> ObtenerTodosAsync()
    {
        using var db = CreateConnection();

        return await db.QueryAsync<VersionCampania>(
            VersionesSql.ObtenerTodos);
    }

    public async Task<VersionCampania?> ObtenerPorIdAsync(long id)
    {
        using var db = CreateConnection();

        return await db.QueryFirstOrDefaultAsync<VersionCampania>(
            VersionesSql.ObtenerPorId,
            new
            {
                IdVersion = id
            });
    }

    public async Task<long> InsertarAsync(VersionCampania version)
    {
        Console.WriteLine("======================================");
        Console.WriteLine("INSERTANDO VERSION");
        Console.WriteLine("======================================");
        Console.WriteLine($"IdCampania        : {version.IdCampania}");
        Console.WriteLine($"MaterialIdDinesat : {version.MaterialIdDinesat}");
        Console.WriteLine($"CodigoMaterial    : {version.CodigoMaterial}");
        Console.WriteLine($"TituloMaterial    : {version.TituloMaterial}");
        Console.WriteLine($"DuracionSegundos  : {version.DuracionSegundos}");
        Console.WriteLine($"OrdenRotacion     : {version.OrdenRotacion}");
        Console.WriteLine($"Preferente        : {version.Preferente}");
        Console.WriteLine($"Activo            : {version.Activo}");
        Console.WriteLine($"FechaAlta         : {version.FechaAlta}");
        Console.WriteLine($"UsuarioAlta       : {version.UsuarioAlta}");
        Console.WriteLine("======================================");

        using var db = CreateConnection();

        return await db.ExecuteScalarAsync<long>(
            VersionesSql.Insertar,
            version);
    }

    public async Task ActualizarAsync(VersionCampania version)
    {
        using var db = CreateConnection();

        await db.ExecuteAsync(
            VersionesSql.Actualizar,
            version);
    }

    public async Task EliminarLogicoAsync(long id)
    {
        using var db = CreateConnection();

        await db.ExecuteAsync(
            VersionesSql.EliminarLogico,
            new
            {
                IdVersion = id,
                FechaModificacion = DateTime.UtcNow,
                UsuarioModificacion = "ADMIN"
            });
    }
}