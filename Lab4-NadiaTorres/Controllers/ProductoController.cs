using Lab4_NadiaTorres.UnitOfWork;
using Lab4_NadiaTorres.Models;
using Lab4_NadiaTorres.Models.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_NadiaTorres.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    [HttpGet]
    public IActionResult ObtenerProductos()
    {
        var productos = _unitOfWork.Productos.GetAll();
        var productoDTO = productos.Select(c => new ProductoDTO
        {
            Nombre = c.Nombre,
            Descripcion = c.Descripcion,
            Precio = c.Precio,
            Stock = c.Stock
            
        }).ToList();
    return Ok(productoDTO);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var producto = _unitOfWork.Productos.GetById(id);
        if (producto == null)
        {
            return NotFound("Producto no encontrado");
        }

        var productoDTO = new ProductoDTO
        {
            Nombre = producto.Nombre,
            Descripcion = producto.Descripcion,
            Precio = producto.Precio,
            Stock = producto.Stock
        };
        return Ok(productoDTO);
    }

    [HttpPost]
    public IActionResult CrearProducto(ProductoDTO proDto)
    {
        var producto = new Producto
        {
            Nombre = proDto.Nombre,
            Descripcion = proDto.Descripcion,
            Precio = proDto.Precio,
            Stock = proDto.Stock,
        };
        
        _unitOfWork.Productos.Add(producto);
        _unitOfWork.SaveChanges();
        return Ok("Producto creado con exito");
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _unitOfWork.Productos.Delete(id);
        _unitOfWork.SaveChanges();
        return Ok("Producto eliminado con éxito");
    }
}