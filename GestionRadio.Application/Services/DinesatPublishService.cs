using GestionRadio.Application.Interfaces;

namespace GestionRadio.Application.Services;

public sealed class DinesatPublishService : IDinesatPublishService
{
    public async Task PublicarProgramacionAsync(long programacionId)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(programacionId);

        await Task.CompletedTask;
    }
}