using Microsoft.EntityFrameworkCore;
using RazorPages.service;
using RazorPages.services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IAlumnoRepositorio, AlumnoRepositorioBD>(); // AddSingleton() = esto permite la inyección de dependencias para instanciar un objeto de la clase AlumnoRepositorio 
//cuando instaciamos un objeto de la clase IAlumnoRepositorio, que no se puede de por sí porque es una interfaz no una clase.
// para crear AlumnoRepositorioBD y unirlo con IAlumno repositorio necesitamos usar AddTransient() 

//para acceder a los objetos de nuestro proyecto (ConnectedService, Dependencies...)
IConfiguration configuracion = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

//con esto metemos en el Service la base de datos
builder.Services.AddDbContextPool<ColegioDBContext>(options => options.UseSqlServer(configuracion.GetConnectionString("ColegioDBConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
