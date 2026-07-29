using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Scheduling.Engine;

/// <summary>
/// Calcula el siguiente ITEMORDER disponible dentro de un bloque de Dinesat.
/// </summary>
public sealed class ItemOrderCalculator
{
    private readonly IDinesatProgramEventRepository _programEventRepository;

    public ItemOrderCalculator(
        IDinesatProgramEventRepository programEventRepository)
    {
        _programEventRepository = programEventRepository
            ?? throw new ArgumentNullException(nameof(programEventRepository));
    }

    /// <summary>
    /// Obtiene el siguiente ITEMORDER disponible.
    /// </summary>
    public async Task<int> ObtenerSiguienteAsync(long programBlockId)
    {
        return await _programEventRepository
            .ObtenerSiguienteItemOrderAsync(programBlockId);
    }
}