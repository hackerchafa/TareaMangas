using MangaApi.Data;
using MangaApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cargar cadena de conexión (Railway o local)
var connectionString = builder.Configuration.GetConnectionString("MangaDb") ??
                       builder.Configuration["MANGADB_CONNECTION"] ??
                       "server=localhost;database=manga_db;user=root;password=;";

// Registrar servicios
builder.Services.AddDbContext<MangaContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IMangaService, MangaService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
