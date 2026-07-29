using Dapper;
using GestionRadio.Application.Interfaces;
using GestionRadio.Application.Mapping;
using GestionRadio.Application.Services;
using GestionRadio.Application.Services.Scheduling;
using GestionRadio.Application.Services.Scheduling.Builders;
using GestionRadio.Application.Services.Scheduling.Distributors;
using GestionRadio.Application.Services.Scheduling.Factories;
using GestionRadio.Application.Services.Scheduling.Generators;
using GestionRadio.Application.Services.Scheduling.Resolvers;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Dinesat;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Repositories;
using GestionRadio.Infrastructure.TypeHandlers;

var builder = WebApplication.CreateBuilder(args);

// ======================================================
// Dapper Type Handlers
// ======================================================

SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
SqlMapper.AddTypeHandler(new TimeOnlyTypeHandler());

// ======================================================
// MVC
// ======================================================

builder.Services.AddControllersWithViews();

// ======================================================
// AutoMapper
// ======================================================

builder.Services.AddAutoMapper(
    cfg => { },
    typeof(ClienteProfile).Assembly);

// ======================================================
// Connection Factory
// ======================================================

builder.Services.AddSingleton<SqlConnectionFactory>();

// ======================================================
// Repositories
// ======================================================

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICampaniaRepository, CampaniaRepository>();
builder.Services.AddScoped<IVersionRepository, VersionRepository>();

builder.Services.AddScoped<IProgramacionRepository, ProgramacionRepository>();
builder.Services.AddScoped<IProgramacionDetalleRepository, ProgramacionDetalleRepository>();

builder.Services.AddScoped<IEmisoraRepository, EmisoraRepository>();
builder.Services.AddScoped<IParrillaRepository, ParrillaRepository>();

// ======================================================
// Dinesat Repositories
// ======================================================

builder.Services.AddScoped<IDinesatProgrammingRepository, DinesatProgrammingRepository>();
builder.Services.AddScoped<IDinesatMaterialRepository, DinesatMaterialRepository>();
builder.Services.AddScoped<IDinesatProgramBlockRepository, DinesatProgramBlockRepository>();
builder.Services.AddScoped<IDinesatProgramEventRepository, DinesatProgramEventRepository>();
builder.Services.AddScoped<IDinesatPublishRepository, DinesatPublishRepository>();

// ======================================================
// Application Services
// ======================================================

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICampaniaService, CampaniaService>();
builder.Services.AddScoped<IVersionService, VersionService>();

builder.Services.AddScoped<IEmisoraService, EmisoraService>();
builder.Services.AddScoped<IParrillaService, ParrillaService>();

builder.Services.AddScoped<IProgramacionService, ProgramacionService>();
builder.Services.AddScoped<IProgramacionDetalleService, ProgramacionDetalleService>();

builder.Services.AddScoped<IDinesatMaterialService, DinesatMaterialService>();
builder.Services.AddScoped<IDinesatProgramEventService, DinesatProgramEventService>();
builder.Services.AddScoped<IDinesatPublishService, DinesatPublishService>();

// ======================================================
// Scheduler
// ======================================================

builder.Services.AddScoped<IProgramacionEngineService, ProgramacionEngineService>();
builder.Services.AddScoped<IAutoSchedulerService, AutoSchedulerService>();

// ======================================================
// Scheduler - Builders
// ======================================================

builder.Services.AddScoped<TimelineBuilder>();
builder.Services.AddScoped<CommercialQueueBuilder>();
builder.Services.AddScoped<ProgramEventBuilder>();

// ======================================================
// Scheduler - Distributors
// ======================================================

builder.Services.AddScoped<CommercialDistributor>();

// ======================================================
// Scheduler - Factories
// ======================================================

builder.Services.AddScoped<ProgramacionDetalleFactory>();

// ======================================================
// Scheduler - Resolvers
// ======================================================

builder.Services.AddScoped<CampaignResolver>();
builder.Services.AddScoped<VersionResolver>();
builder.Services.AddScoped<ProgrammingResolver>();
builder.Services.AddScoped<BlockResolver>();
builder.Services.AddScoped<MaterialResolver>();

// ======================================================
// Scheduler - Generators
// ======================================================

builder.Services.AddScoped<ProgramacionDetalleGenerator>();

// ======================================================
// Build
// ======================================================

var app = builder.Build();

// ======================================================
// Pipeline
// ======================================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();