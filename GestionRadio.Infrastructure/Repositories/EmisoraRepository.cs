using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Sql;

namespace GestionRadio.Infrastructure.Repositories;

public sealed class EmisoraRepository
    : BaseRepository, IEmisoraRepository
{
    public EmisoraRepository(
        SqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }


    //==================================================
    // OBTENER TODAS
    //==================================================

    public async Task<IEnumerable<Emisora>> ObtenerTodasAsync()
    {
        using var connection = CreateConnection();

        return await connection.QueryAsync<Emisora>(
            EmisoraSql.ObtenerTodas);
    }


    //==================================================
    // OBTENER ACTIVAS
    //==================================================

    public async Task<IEnumerable<Emisora>> ObtenerActivasAsync()
    {
        using var connection = CreateConnection();

        return await connection.QueryAsync<Emisora>(
            EmisoraSql.ObtenerActivas);
    }


    //==================================================
    // OBTENER POR ID
    //==================================================

    public async Task<Emisora?> ObtenerPorIdAsync(
        long id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));


        using var connection = CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<Emisora>(
            EmisoraSql.ObtenerPorId,
            new
            {
                Id = id
            });
    }
}