using GestionRadio.Application.Services.Scheduling.Models;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Scheduling.Builders;

public sealed class TimelineBuilder
{
    private readonly IParrillaRepository _parrillaRepository;


    public TimelineBuilder(
        IParrillaRepository parrillaRepository)
    {
        _parrillaRepository = parrillaRepository;
    }



    public async Task<SchedulingDay> BuildAsync(
        DateOnly fecha,
        long emisoraId)
    {
        var eventos =
            await _parrillaRepository.ObtenerTimelineAsync(
                emisoraId,
                fecha);



        var schedulingDay = new SchedulingDay
        {
            Fecha = fecha,
            EmisoraId = emisoraId
        };



        foreach (var evento in eventos)
        {

            var block = new TimelineBlock
            {
                Hora = TimeOnly.FromTimeSpan(evento.Hora),

                Descripcion =
                    evento.Descripcion ?? string.Empty,

                PermitePublicidad =
                    evento.PermitePublicidad,

                DuracionMaximaSegundos =
                    evento.DuracionMaximaSegundos ?? 0
            };


            schedulingDay.Blocks.Add(block);
        }



        return schedulingDay;
    }
}