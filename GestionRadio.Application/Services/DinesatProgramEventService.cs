using GestionRadio.Application.Interfaces;
using GestionRadio.Domain.Entities;
using GestionRadio.Domain.Interfaces;

namespace GestionRadio.Application.Services;

/// <summary>
/// Servicio para consultar los eventos de programación de Dinesat.
/// </summary>
public sealed class DinesatProgramEventService : IDinesatProgramEventService
{
    private readonly IDinesatProgramEventRepository _repository;

    public DinesatProgramEventService(
        IDinesatProgramEventRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    /// <summary>
    /// Obtiene todos los eventos de un bloque.
    /// </summary>
    public async Task<IReadOnlyList<DinesatProgramEvent>> ObtenerPorBloqueAsync(long programBlockId)
    {
        if (programBlockId <= 0)
            throw new ArgumentOutOfRangeException(nameof(programBlockId));

        return await _repository.ObtenerPorBloqueAsync(programBlockId);
    }

    /// <summary>
    /// Obtiene un evento por su identificador.
    /// </summary>
    public async Task<DinesatProgramEvent?> ObtenerPorIdAsync(long programEventId)
    {
        if (programEventId <= 0)
            throw new ArgumentOutOfRangeException(nameof(programEventId));

        return await _repository.ObtenerPorIdAsync(programEventId);
    }
}