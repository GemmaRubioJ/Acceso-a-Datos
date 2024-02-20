using Microsoft.EntityFrameworkCore;
using MVC2024.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//apartir de aqui 

IConfiguration configuracion = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json")
	.AddEnvironmentVariables()
	.Build();

builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer(configuracion.GetConnectionString("Contexto")));

//hasta aqui 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
