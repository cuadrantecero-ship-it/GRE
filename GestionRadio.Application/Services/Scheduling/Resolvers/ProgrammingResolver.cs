using GestionRadio.Application.DTOs.Programacion;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services.Scheduling.Resolvers;

/// <summary>
/// Localiza la programación de Dinesat correspondiente
/// a la fecha y emisora solicitadas.
/// </summary>
public sealed class ProgrammingResolver
{
    private readonly IDinesatProgrammingRepository _programmingRepository;

    public ProgrammingResolver(
        IDinesatProgrammingRepository programmingRepository)
    {
        _programmingRepository = programmingRepository
            ?? throw new ArgumentNullException(nameof(programmingRepository));
    }

    /// <summary>
    /// Obtiene la programación de Dinesat para la fecha y emisora.
    /// </summary>
    public async Task<DinesatProgramming> ObtenerAsync(
        ProgramacionCreateDto request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var programming =
            await _programmingRepository.ObtenerPorFechaAsync(
                request.Fecha,
                request.EmisoraId);

        if (programming is null)
        {
            throw new InvalidOperationException(
                $"No existe una programación de Dinesat para la fecha {request.Fecha:yyyy-MM-dd} y la emisora {request.EmisoraId}.");
        }

        return programming;
    }
}