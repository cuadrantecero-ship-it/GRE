using GestionRadio.Domain.Interfaces;
using GestionRadio.Web.Models.ViewModels.Dinesat;
using Microsoft.AspNetCore.Mvc;

namespace GestionRadio.Web.Controllers;

public class DinesatProgramacionController : Controller
{
    private readonly IDinesatProgrammingRepository _programmingRepository;
    private readonly IDinesatProgramBlockRepository _blockRepository;
    private readonly IDinesatProgramEventRepository _eventRepository;

    public DinesatProgramacionController(
        IDinesatProgrammingRepository programmingRepository,
        IDinesatProgramBlockRepository blockRepository,
        IDinesatProgramEventRepository eventRepository)
    {
        _programmingRepository = programmingRepository
            ?? throw new ArgumentNullException(nameof(programmingRepository));

        _blockRepository = blockRepository
            ?? throw new ArgumentNullException(nameof(blockRepository));

        _eventRepository = eventRepository
            ?? throw new ArgumentNullException(nameof(eventRepository));
    }

    public async Task<IActionResult> Index(long? programmingId)
    {
        // Si no se recibe un ProgrammingId, obtener la programación activa.
        if (!programmingId.HasValue)
        {
            var programacion = await _programmingRepository.ObtenerActivaAsync();

            if (programacion == null)
            {
                return View(new DinesatProgramacionViewModel());
            }

            programmingId = programacion.ProgrammingId;
        }

        var bloques = await _blockRepository.ObtenerPorProgramacionAsync(programmingId.Value);

        var model = new DinesatProgramacionViewModel
        {
            ProgrammingId = programmingId.Value
        };

        foreach (var bloque in bloques)
        {
            var bloqueVm = new DinesatBloqueViewModel
            {
                ProgramBlockId = bloque.ProgramBlockId,
                HoraInicio = bloque.HoraInicio,
                Nombre = bloque.Nombre
            };

            var eventos = await _eventRepository.ObtenerPorBloqueAsync(bloque.ProgramBlockId);

            foreach (var evento in eventos)
            {
                bloqueVm.Eventos.Add(new DinesatEventoViewModel
                {
                    ProgramEventId = evento.ProgramEventId,
                    ItemOrder = evento.ItemOrder,

                    MaterialId = evento.MaterialId,
                    MaterialCode = evento.MaterialCode,
                    MaterialTitle = evento.MaterialTitle,
                    LengthFrames = evento.LengthFrames,

                    TrafficCode = evento.TrafficCode,
                    TrafficIndex = evento.TrafficIndex,
                    LiveDescription = evento.LiveDescription,
                    LiveLength = evento.LiveLength
                });
            }

            model.Bloques.Add(bloqueVm);
        }

        return View(model);
    }
}