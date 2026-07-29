using GestionRadio.Application.DTOs.Programacion;
using GestionRadio.Application.Interfaces;
using GestionRadio.Application.Services.Scheduling.Generators;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Scheduling;

public sealed class AutoSchedulerService : IAutoSchedulerService
{
    private readonly IParrillaRepository _parrillaRepository;
    private readonly IProgramacionRepository _programacionRepository;
    private readonly IProgramacionDetalleRepository _detalleRepository;
    private readonly ICampaniaRepository _campaniaRepository;
    private readonly IVersionRepository _versionRepository;
    private readonly ProgramacionDetalleGenerator _programacionDetalleGenerator;

    public AutoSchedulerService(
        IParrillaRepository parrillaRepository,
        IProgramacionRepository programacionRepository,
        IProgramacionDetalleRepository detalleRepository,
        ICampaniaRepository campaniaRepository,
        IVersionRepository versionRepository,
        ProgramacionDetalleGenerator programacionDetalleGenerator)
    {
        _parrillaRepository = parrillaRepository
            ?? throw new ArgumentNullException(nameof(parrillaRepository));

        _programacionRepository = programacionRepository
            ?? throw new ArgumentNullException(nameof(programacionRepository));

        _detalleRepository = detalleRepository
            ?? throw new ArgumentNullException(nameof(detalleRepository));

        _campaniaRepository = campaniaRepository
            ?? throw new ArgumentNullException(nameof(campaniaRepository));

        _versionRepository = versionRepository
            ?? throw new ArgumentNullException(nameof(versionRepository));

        _programacionDetalleGenerator = programacionDetalleGenerator
            ?? throw new ArgumentNullException(nameof(programacionDetalleGenerator));
    }

    public async Task<ProgramacionDto> GenerarProgramacionAsync(
        DateOnly fecha,
        long emisoraId,
        long parrillaId)
    {
        //==================================================
        // Crear encabezado de Programación
        //==================================================

        var programacion = new Programacion
        {
            EmisoraId = emisoraId,
            ParrillaId = parrillaId,
            Fecha = fecha,

            Estado = 1,
            Activa = true,

            FechaCreacion = DateTime.UtcNow,
            UsuarioCreacion = "AUTO-SCHEDULER"
        };

        var programacionId =
            await _programacionRepository.InsertarAsync(programacion);

        programacion.ProgramacionId = programacionId;

        //==================================================
        // Generar automáticamente los detalles
        //==================================================

        await _programacionDetalleGenerator.GenerarAsync(programacion);

        //==================================================
        // Regresar DTO
        //==================================================

        return new ProgramacionDto
        {
            ProgramacionId = programacion.ProgramacionId,
            EmisoraId = programacion.EmisoraId,
            ParrillaId = programacion.ParrillaId,
            Fecha = programacion.Fecha,
            Estado = programacion.Estado,
            Activa = programacion.Activa
        };
    }
}