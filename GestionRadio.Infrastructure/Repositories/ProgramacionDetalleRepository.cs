using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Sql;

namespace GestionRadio.Infrastructure.Repositories;

public sealed class ProgramacionDetalleRepository
    : BaseRepository, IProgramacionDetalleRepository
{
    public ProgramacionDetalleRepository(
        SqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<ProgramacionDetalle>> ObtenerPorProgramacionAsync(
        long programacionId)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(programacionId);

        using var connection = CreateConnection();

        return await connection.QueryAsync<ProgramacionDetalle>(
            ProgramacionDetalleSql.ObtenerPorProgramacion,
            new
            {
                ProgramacionId = programacionId
            });
    }

    public async Task<ProgramacionDetalle?> ObtenerPorIdAsync(
        long programacionDetalleId)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(programacionDetalleId);

        using var connection = CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<ProgramacionDetalle>(
            ProgramacionDetalleSql.ObtenerPorId,
            new
            {
                Id = programacionDetalleId
            });
    }

    public async Task<long> InsertarAsync(
        ProgramacionDetalle detalle)
    {
        ArgumentNullException.ThrowIfNull(detalle);

        using var connection = CreateConnection();

        return await connection.ExecuteScalarAsync<long>(
            ProgramacionDetalleSql.Insertar,
            detalle);
    }

    public async Task ActualizarAsync(
        ProgramacionDetalle detalle)
    {
        ArgumentNullException.ThrowIfNull(detalle);

        using var connection = CreateConnection();

        await connection.ExecuteAsync(
            ProgramacionDetalleSql.Actualizar,
            detalle);
    }

    public async Task EliminarLogicoAsync(
        long programacionDetalleId)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(programacionDetalleId);

        using var connection = CreateConnection();

        await connection.ExecuteAsync(
            ProgramacionDetalleSql.EliminarLogico,
            new
            {
                Id = programacionDetalleId
            });
    }
}