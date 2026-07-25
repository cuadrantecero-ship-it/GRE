using Dapper;
using GestionRadio.Application.Interfaces;
using GestionRadio.Application.Mapping;
using GestionRadio.Application.Services;
using GestionRadio.Infrastructure.Persistence;
using GestionRadio.Infrastructure.Repositories;
using GestionRadio.Domain.Interfaces;
using GestionRadio.Infrastructure.Dinesat;
using GestionRadio.Infrastructure.TypeHandlers;

var builder = WebApplication.CreateBuilder(args);

// ======================================
// Dapper TypeHandlers
// ======================================
SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

// MVC
builder.Services.AddControllersWithViews();

// AutoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(ClienteProfile).Assembly);

// SQL Connection Factory
builder.Services.AddSingleton<SqlConnectionFactory>();

// =========================
// Repositories
// =========================
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICampaniaRepository, CampaniaRepository>();
builder.Services.AddScoped<IVersionRepository, VersionRepository>();
builder.Services.AddScoped<MaterialRepository>();

//==========================================================
// DINESAT
//==========================================================

builder.Services.AddScoped<IDinesatMaterialRepository, DinesatMaterialRepository>();
builder.Services.AddScoped<IDinesatMaterialService, DinesatMaterialService>();

// =========================
// Services
// =========================
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICampaniaService, CampaniaService>();
builder.Services.AddScoped<IVersionService, VersionService>();
builder.Services.AddScoped<MaterialRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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