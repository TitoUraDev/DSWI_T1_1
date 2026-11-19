using System.Globalization;
using DSWI_T1_01.Data;
using DSWI_T1_01.Repositories;
using DSWI_T1_01.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Contexto generado con Scaffold
builder.Services.AddDbContext<ClinicaBdContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicaDB")));

// Inyección de dependencias: Repositories
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<ICitaRepository, CitaRepository>();

// Inyección de dependencias: Services
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<ICitaService, CitaService>();

var app = builder.Build();

// Cultura fija (punto decimal) para que 2.50 se interprete igual en cualquier equipo
var cultura = new CultureInfo("en-US");
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(cultura),
    SupportedCultures = new List<CultureInfo> { cultura },
    SupportedUICultures = new List<CultureInfo> { cultura }
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
