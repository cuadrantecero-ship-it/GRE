using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Scheduling.Resolvers;

/// <summary>
/// Localiza el bloque de programación de Dinesat correspondiente
/// a una hora específica.
/// </summary>
public sealed class BlockResolver
{
    private readonly IDinesatProgramBlockRepository _programBlockRepository;

    public BlockResolver(
        IDinesatProgramBlockRepository programBlockRepository)
    {
        _programBlockRepository = programBlockRepository
            ?? throw new ArgumentNullException(nameof(programBlockRepository));
    }

    /// <summary>
    /// Obtiene el bloque correspondiente a una programación y hora.
    /// </summary>
    public async Task<DinesatProgramBlock> ObtenerAsync(
        long programId,
        TimeOnly horaProgramada)
    {
        var bloques = await _programBlockRepository.ObtenerPorProgramacionAsync(programId);

        var horaBuscada = horaProgramada.ToString("HH:mm:ss");

        var bloque = bloques.FirstOrDefault(x =>
            x.HoraInicio.Trim() == horaBuscada);

        if (bloque is null)
        {
            throw new InvalidOperationException(
                $"No existe un bloque de Dinesat para la hora {horaBuscada}.");
        }

        return bloque;
    }
}