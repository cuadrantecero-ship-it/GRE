using Dapper;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Sql;

namespace GestionRadio.Infrastructure.Repositories;

public sealed class ParrillaRepository : BaseRepository, IParrillaRepository
{
    public ParrillaRepository(
        SqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }



    //====================================================
    // PARRILLAS
    //====================================================

    public async Task<IEnumerable<Parrilla>> ObtenerTodasAsync()
    {
        using var db = CreateConnection();

        return await db.QueryAsync<Parrilla>(
            ParrillasSql.ObtenerTodas);
    }



    public async Task<Parrilla?> ObtenerPorIdAsync(
        long id)
    {
        using var db = CreateConnection();

        return await db.QueryFirstOrDefaultAsync<Parrilla>(
            ParrillasSql.ObtenerPorId,
            new
            {
                Id = id
            });
    }



    public async Task<long> InsertarAsync(
        Parrilla parrilla)
    {
        using var db = CreateConnection();

        return await db.ExecuteScalarAsync<long>(
            ParrillasSql.Insertar,
            parrilla);
    }



    public async Task ActualizarAsync(
        Parrilla parrilla)
    {
        using var db = CreateConnection();

        await db.ExecuteAsync(
            ParrillasSql.Actualizar,
            parrilla);
    }



    public async Task EliminarAsync(
        long id)
    {
        using var db = CreateConnection();

        await db.ExecuteAsync(
            ParrillasSql.Eliminar,
            new
            {
                Id = id
            });
    }




    //====================================================
    // EVENTOS DE PARRILLA
    //====================================================

    public async Task<IEnumerable<ParrillaEvento>> ObtenerEventosAsync(
        long parrillaId)
    {
        using var db = CreateConnection();

        return await db.QueryAsync<ParrillaEvento>(
            ParrillasSql.ObtenerEventos,
            new
            {
                ParrillaId = parrillaId
            });
    }



    public async Task GuardarEventosAsync(
        long parrillaId,
        IEnumerable<ParrillaEvento> eventos)
    {
        using var db = CreateConnection();


        await db.ExecuteAsync(
            ParrillasSql.EliminarEventos,
            new
            {
                ParrillaId = parrillaId
            });



        foreach (var evento in eventos)
        {
            evento.ParrillaId = parrillaId;


            await db.ExecuteAsync(
                ParrillasSql.InsertarEvento,
                evento);
        }
    }




    public async Task<IEnumerable<TipoEvento>> ObtenerTiposEventoAsync()
    {
        using var db = CreateConnection();

        return await db.QueryAsync<TipoEvento>(
            ParrillasSql.ObtenerTiposEvento);
    }




    //====================================================
    // CRUD EVENTOS INDIVIDUALES
    //====================================================

    public async Task InsertarEventoAsync(
    ParrillaEvento evento)
    {
        using var db = CreateConnection();


        Console.WriteLine("==============================");
        Console.WriteLine($"ParrillaId: {evento.ParrillaId}");
        Console.WriteLine($"TipoEventoId: {evento.TipoEventoId}");
        Console.WriteLine($"Descripcion: {evento.Descripcion}");
        Console.WriteLine("==============================");


        await db.ExecuteAsync(
            ParrillasSql.InsertarEvento,
            evento);
    }




    public async Task ActualizarEventoAsync(
        ParrillaEvento evento)
    {
        using var db = CreateConnection();


        await db.ExecuteAsync(
            ParrillasSql.ActualizarEvento,
            evento);
    }




    public async Task EliminarEventoAsync(
        long eventoId)
    {
        using var db = CreateConnection();


        await db.ExecuteAsync(
            ParrillasSql.EliminarEvento,
            new
            {
                EventoId = eventoId
            });
    }




    //====================================================
    // TIMELINE PROGRAMACION
    //====================================================

    public async Task<IEnumerable<ParrillaEvento>> ObtenerTimelineAsync(
        long emisoraId,
        DateOnly fecha)
    {
        using var db = CreateConnection();


        return await db.QueryAsync<ParrillaEvento>(
            ParrillasSql.ObtenerTimeline,
            new
            {
                EmisoraId = emisoraId,
                Fecha = fecha
            });
    }
}