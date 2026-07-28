using GestionRadio.Agent.Dinesat;
using GestionRadio.Agent.Models;

namespace GestionRadio.Agent;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IDinesatSession _session;
    private readonly IDinesatProgrammingService _programmingService;

    public Worker(
        ILogger<Worker> logger,
        IDinesatSession session,
        IDinesatProgrammingService programmingService)
    {
        _logger = logger;
        _session = session;
        _programmingService = programmingService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            _logger.LogInformation("==================================");
            _logger.LogInformation("LECTURA DE PROGRAMACIÓN DINESAT");
            _logger.LogInformation("==================================");

            if (!await _session.LoginAsync())
            {
                _logger.LogError("No fue posible iniciar sesión.");
                return;
            }

            _logger.LogInformation("Login correcto");
            _logger.LogInformation("SessionId: {SessionId}", _session.SessionId);

            var xml = await _programmingService.GetProgrammingByDateAsync(
                "1146901",
                DateOnly.FromDateTime(DateTime.Today),
                1);

            var parser = new ProgrammingXmlParser();

            List<ProgrammingBlock> bloques = parser.Parse(xml);

            _logger.LogInformation("");
            _logger.LogInformation("========== RESUMEN ==========");
            _logger.LogInformation("Bloques encontrados: {Cantidad}", bloques.Count);
            _logger.LogInformation("");

            foreach (var bloque in bloques)
            {
                _logger.LogInformation(
                    "[{Hora}] {Descripcion}",
                    bloque.BlockTime.ToString(@"hh\:mm"),
                    bloque.Description);

                foreach (var evento in bloque.Events)
                {
                    _logger.LogInformation(
                        "   Item:{Item} | Código:{Codigo} | Título:{Titulo} | Material:{Material}",
                        evento.ItemId,
                        evento.Code,
                        evento.Title,
                        evento.MaterialId);
                }

                _logger.LogInformation("");
            }

            await _session.LogoutAsync();

            _logger.LogInformation("Sesión cerrada.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error durante la lectura de programación.");
        }

        Environment.Exit(0);
    }
}