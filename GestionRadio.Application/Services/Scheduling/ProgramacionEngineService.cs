using GestionRadio.Application.DTOs.Programacion;
using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Scheduling;

/// <summary>
/// Motor de sincronización entre GESTIÓN RADIO y Dinesat.
/// Primera versión funcional.
/// </summary>
public sealed class ProgramacionEngineService : IProgramacionEngineService
{
    private readonly IProgramacionRepository _programacionRepository;
    private readonly IProgramacionDetalleRepository _detalleRepository;
    private readonly IDinesatMaterialRepository _materialRepository;
    private readonly IDinesatProgramEventRepository _eventRepository;

    public ProgramacionEngineService(
        IProgramacionRepository programacionRepository,
        IProgramacionDetalleRepository detalleRepository,
        IDinesatMaterialRepository materialRepository,
        IDinesatProgramEventRepository eventRepository)
    {
        _programacionRepository = programacionRepository
            ?? throw new ArgumentNullException(nameof(programacionRepository));

        _detalleRepository = detalleRepository
            ?? throw new ArgumentNullException(nameof(detalleRepository));

        _materialRepository = materialRepository
            ?? throw new ArgumentNullException(nameof(materialRepository));

        _eventRepository = eventRepository
            ?? throw new ArgumentNullException(nameof(eventRepository));
    }


    public async Task<ProgramacionDto> ProgramarAsync(long programacionId)
    {
        if (programacionId <= 0)
            throw new ArgumentOutOfRangeException(nameof(programacionId));


        var programacion =
            await _programacionRepository.ObtenerPorIdAsync(programacionId);


        if (programacion is null)
        {
            throw new InvalidOperationException(
                "La programación no existe.");
        }


        var detalles =
            await _detalleRepository.ObtenerPorProgramacionAsync(
                programacionId);


        foreach (var detalle in detalles)
        {
            if (detalle.Sincronizado)
                continue;


            if (string.IsNullOrWhiteSpace(detalle.CodigoMaterial))
            {
                throw new InvalidOperationException(
                    $"El detalle {detalle.ProgramacionDetalleId} no tiene código de material.");
            }


            if (!detalle.DinesatProgramBlockId.HasValue)
            {
                throw new InvalidOperationException(
                    $"El detalle {detalle.ProgramacionDetalleId} no tiene bloque Dinesat.");
            }


            var material =
                await _materialRepository.ObtenerPorCodigoAsync(
                    detalle.CodigoMaterial);


            if (material is null)
            {
                throw new InvalidOperationException(
                    $"No existe el material {detalle.CodigoMaterial} en Dinesat.");
            }


            var itemOrder =
                await _eventRepository.ObtenerSiguienteItemOrderAsync(
                    detalle.DinesatProgramBlockId.Value);


            var evento = new DinesatProgramEvent
            {
                ProgramBlockId =
                    detalle.DinesatProgramBlockId.Value,

                ItemOrder = itemOrder,

                MaterialId =
                    material.MaterialIdDinesat,

                MaterialCode =
                    material.Codigo,

                MaterialTitle =
                    material.Titulo,

                LengthFrames =
                    detalle.DuracionSegundos,

                Condition = 0,

                TrafficCode = "COM",

                TrafficIndex = 0,

                LiveDescription = null,

                LiveLength = 0
            };


            var programEventId =
                await _eventRepository.InsertarAsync(evento);


            detalle.DinesatProgramEventId = programEventId;
            detalle.DinesatMaterialId = material.MaterialIdDinesat;

            detalle.CodigoMaterial = material.Codigo;
            detalle.TituloMaterial = material.Titulo;

            detalle.Sincronizado = true;

            detalle.FechaModificacion = DateTime.Now;
            detalle.UsuarioModificacion = "ADMIN";


            await _detalleRepository.ActualizarAsync(detalle);
        }


        return new ProgramacionDto
        {
            ProgramacionId = programacion.ProgramacionId,
            EmisoraId = programacion.EmisoraId,
            ParrillaId = programacion.ParrillaId,
            Fecha = programacion.Fecha,
            DinesatProgrammingId = programacion.DinesatProgrammingId,
            Estado = 3,
            Activa = programacion.Activa
        };
    }
}