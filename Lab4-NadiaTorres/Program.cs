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
