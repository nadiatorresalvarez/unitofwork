using Lab4_NadiaTorres.Interfaces;
using Lab4_NadiaTorres.Models;
using Lab4_NadiaTorres.Repositories;
using Lab4_NadiaTorres.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Agregar servicios de Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<dbContextLab4>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//injection
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IDetallesordenRepository, DetallesordenRepository>();
builder.Services.AddScoped<IOrdeneRepository, OrdeneRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Aquí ponemos tu clase exacta: dbContextLab4
        var context = services.GetRequiredService<dbContextLab4>();
        
        // Este comando crea las tablas (Productos, etc.) en Render automáticamente
        context.Database.EnsureCreated(); 
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al crear la base de datos.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        c.RoutePrefix = string.Empty; // Swagger en la raiz del proyecto (opcional)
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
