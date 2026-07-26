using Dapper;
using GestionRadio.Application.Interfaces;
using GestionRadio.Application.Mapping;
using GestionRadio.Application.Services;
using GestionRadio.Application.Services.Scheduling.Resolvers;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Dinesat;
using GestionRadio.Infrastructure.Dinesat.Connection;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Repositories;
using GestionRadio.Infrastructure.TypeHandlers;

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
builder.Services.AddSingleton<DinesatConnectionFactory>();

// ======================================
// Repositories
// ======================================
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICampaniaRepository, CampaniaRepository>();
builder.Services.AddScoped<IVersionRepository, VersionRepository>();
builder.Services.AddScoped<IProgramacionRepository, ProgramacionRepository>();

// Repositorios Dinesat
builder.Services.AddScoped<IDinesatProgrammingRepository, DinesatProgrammingRepository>();
builder.Services.AddScoped<IDinesatMaterialRepository, DinesatMaterialRepository>();
builder.Services.AddScoped<IDinesatProgramBlockRepository, DinesatProgramBlockRepository>();
builder.Services.AddScoped<IDinesatProgramEventRepository, DinesatProgramEventRepository>();

// MaterialRepository (si es utilizado directamente)
builder.Services.AddScoped<MaterialRepository>();

// ======================================
// Resolvers
// ======================================
builder.Services.AddScoped<VersionResolver>();

// ======================================
// Services
// ======================================
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICampaniaService, CampaniaService>();
builder.Services.AddScoped<IVersionService, VersionService>();
builder.Services.AddScoped<IProgramacionService, ProgramacionService>();

// Servicios Dinesat
builder.Services.AddScoped<IDinesatMaterialService, DinesatMaterialService>();
builder.Services.AddScoped<IDinesatProgramEventService, DinesatProgramEventService>();

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