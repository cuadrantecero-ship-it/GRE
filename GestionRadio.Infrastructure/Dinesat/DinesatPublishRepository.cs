using System.Data;
using Dapper;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Sql;

namespace GestionRadio.Infrastructure.Dinesat;

public sealed class DinesatPublishRepository : IDinesatPublishRepository
{
    //=========================================================
    // CONFIGURACIÓN
    //=========================================================

    private const int StationId = 1146901;

    private readonly SqlConnectionFactory _connectionFactory;

    public DinesatPublishRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    //=========================================================
    // MÉTODO PRINCIPAL
    //=========================================================

    public async Task PublicarAsync(DateOnly fecha)
    {
        using var connection = _connectionFactory.CreateConnection();

        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            int pgmId = await ObtenerOCrearProgrammingAsync(
                connection,
                transaction,
                fecha);

            //=================================================
            // PARTE 2
            //
            // Aquí continuará:
            //
            // Crear bloques
            // Buscar materiales
            // Crear eventos
            //
            // (No hacer nada todavía)
            //=================================================

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    //=========================================================
    // PROGRAMMING
    //=========================================================

    private async Task<int> ObtenerOCrearProgrammingAsync(
        IDbConnection connection,
        IDbTransaction transaction,
        DateOnly fecha)
    {
        int? existente = await connection.QueryFirstOrDefaultAsync<int?>(
            DinesatPublishSql.ExisteProgramming,
            new
            {
                StationId,
                ProgramDate = fecha
            },
            transaction);

        if (existente.HasValue)
            return existente.Value;

        int nuevoId = await connection.ExecuteScalarAsync<int>(
            DinesatPublishSql.CrearProgramming,
            new
            {
                StationId,
                ProgramDate = fecha,
                UtcDate = DateTime.UtcNow.Date,
                UtcTime = DateTime.UtcNow.TimeOfDay
            },
            transaction);

        return nuevoId;
    }
}