using GestionRadio.Domain.Entities;

namespace GestionRadio.Application.Services.Scheduling.Builders;

/// <summary>
/// Construye un evento de programación listo para insertarse en Dinesat.
/// No realiza acceso a datos; únicamente crea la entidad.
/// </summary>
public sealed class ProgramEventBuilder
{
    /// <summary>
    /// Construye un evento de tipo Spot Comercial.
    /// </summary>
    public DinesatProgramEvent ConstruirSpot(
        long programBlockId,
        int itemOrder,
        long materialId,
        string trafficCode)
    {
        return new DinesatProgramEvent
        {
            ProgramBlockId = programBlockId,
            ItemOrder = itemOrder,
            MaterialId = materialId,

            // Valores validados en Dinesat
            Condition = 1,
            TrafficCode = trafficCode,
            TrafficIndex = 0,
            LiveDescription = string.Empty,
            LiveLength = 0
        };
    }
}