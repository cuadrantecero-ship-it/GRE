using Dapper;
using GestionRadio.Application.Interfaces;
using GestionRadio.Application.Scheduling.Engine;
using GestionRadio.Application.Mapping;
using GestionRadio.Application.Services;
using GestionRadio.Application.Services.Scheduling.Resolvers;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Dinesat;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Repositories;
using GestionRadio.Infrastructure.TypeHandlers;
using GestionRadio.Application.Services.Scheduling;
using GestionRadio.Application.Services.Scheduling.Builders;

var builder = WebApplication.CreateBuilder(args);

// ======================================
// Dapper TypeHandlers
// ======================================
SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

// ======================================
// MVC
// ======================================
builder.Services.AddControllersWithViews();

// ======================================
// AutoMapper
// ======================================
builder.Services.AddAutoMapper(cfg => { }, typeof(ClienteProfile).Assembly);

// ======================================
// Connection Factories
// ======================================
builder.Services.AddSingleton<SqlConnectionFactory>();

// ======================================
// Repositories
// ======================================

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICampaniaRepository, CampaniaRepository>();
builder.Services.AddScoped<IVersionRepository, VersionRepository>();
builder.Services.AddScoped<IProgramacionRepository, ProgramacionRepository>();
builder.Services.AddScoped<IParrillaRepository, ParrillaRepository>();

// Repositorios Dinesat
builder.Services.AddScoped<IDinesatProgrammingRepository, DinesatProgrammingRepository>();
builder.Services.AddScoped<IDinesatMaterialRepository, DinesatMaterialRepository>();
builder.Services.AddScoped<IDinesatProgramBlockRepository, DinesatProgramBlockRepository>();
builder.Services.AddScoped<IDinesatProgramEventRepository, DinesatProgramEventRepository>();
builder.Services.AddScoped<IProgramacionEngineService, ProgramacionEngineService>();

// MaterialRepository (si es utilizado directamente)
builder.Services.AddScoped<MaterialRepository>();
builder.Services.AddScoped<ProgramEventBuilder>();

// ======================================
// Resolvers
// ======================================
builder.Services.AddScoped<VersionResolver>();
builder.Services.AddScoped<ProgrammingResolver>();
builder.Services.AddScoped<BlockResolver>();
builder.Services.AddScoped<MaterialResolver>();

// ======================================
// Services
// ======================================

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICampaniaService, CampaniaService>();
builder.Services.AddScoped<IVersionService, VersionService>();
builder.Services.AddScoped<IProgramacionService, ProgramacionService>();
builder.Services.AddScoped<IParrillaService, ParrillaService>();

// Servicios Dinesat
builder.Services.AddScoped<IDinesatMaterialService, DinesatMaterialService>();
builder.Services.AddScoped<IDinesatProgramEventService, DinesatProgramEventService>();
builder.Services.AddScoped<ItemOrderCalculator>();
builder.Services.AddScoped<MaterialResolver>();

// Motor de rotación
builder.Services.AddScoped<IRotationEngineService, RotationEngineService>();

// ======================================
// Build
// ======================================
var app = builder.Build();

// ======================================
// Pipeline
// ======================================
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