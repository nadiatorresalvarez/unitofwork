using Lab4_NadiaTorres.Interfaces;
using Lab4_NadiaTorres.Models;
using Lab4_NadiaTorres.Repositories;
using Lab4_NadiaTorres.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- CORRECCIÓN BASE DE DATOS INICIO ---
// 1. Leemos la cadena local (appsettings.json) por defecto
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Buscamos la variable de entorno de Render (RENDER_DB)
var renderDB = Environment.GetEnvironmentVariable("RENDER_DB");

// 3. Si existe la variable de Render, SOBRESCRIBIMOS la conexión
if (!string.IsNullOrEmpty(renderDB))
{
    connectionString = renderDB;
}

// 4. Usamos la cadena elegida (ya sea local o nube)
builder.Services.AddDbContext<dbContextLab4>(options =>
    options.UseNpgsql(connectionString));
// --- CORRECCIÓN BASE DE DATOS FIN ---


// Inyecciones de dependencias
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IDetallesordenRepository, DetallesordenRepository>();
builder.Services.AddScoped<IOrdeneRepository, OrdeneRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 

var app = builder.Build();

// Crear base de datos si no existe (para Render)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<dbContextLab4>();
        context.Database.EnsureCreated(); 
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al crear la base de datos.");
    }
}

// --- CORRECCIÓN SWAGGER INICIO ---
// Hemos sacado Swagger del "if (app.Environment.IsDevelopment())"
// para que puedas verlo en Render (que corre en Production).
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    // Ajuste para que funcione tanto en local como en nube
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    c.RoutePrefix = string.Empty; // Swagger en la raiz
});
// --- CORRECCIÓN SWAGGER FIN ---

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
