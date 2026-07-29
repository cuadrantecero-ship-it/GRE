using GestionRadio.Application.DTOs.Programacion;

namespace GestionRadio.Application.Interfaces;

public interface IAutoSchedulerService
{
    Task<ProgramacionDto> GenerarProgramacionAsync(
        DateOnly fecha,
        long emisoraId,
        long parrillaId);
}