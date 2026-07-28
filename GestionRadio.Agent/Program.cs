using GestionRadio.Agent;
using GestionRadio.Agent.Configuration;
using GestionRadio.Agent.Dinesat;

var builder = Host.CreateApplicationBuilder(args);

// Configuración
builder.Services.Configure<DinesatOptions>(
    builder.Configuration.GetSection("Dinesat"));

// Servicios Dinesat
builder.Services.AddSingleton<IDinesatSession, DinesatSession>();
builder.Services.AddSingleton<IDinesatStationService, DinesatStationService>();
builder.Services.AddSingleton<IDinesatProgrammingService, DinesatProgrammingService>();

// Worker
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();