using Lab4_NadiaTorres.Models;
using Lab4_NadiaTorres.Models.DTOS;
using Lab4_NadiaTorres.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_NadiaTorres.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DetallesordenController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public DetallesordenController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    public IActionResult ObtenerDetallesordenes()
    {
        var detallesordenes = _unitOfWork.Detallesordenes.GetAll();
        var detallesordenesDTO = detallesordenes.Select(c => new DetallesordenDTO
        {
            Ordenid = c.Ordenid,
            Productoid = c.Productoid,
            Cantidad = c.Cantidad,
            Precio = c.Precio,
        }).ToList();
        return Ok(detallesordenesDTO);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var detallesorden = _unitOfWork.Detallesordenes.GetById(id);
        if (detallesorden == null)
        {
            return NotFound("Detalles de orden no encontrado");
        }

        var detallesordenDTO = new DetallesordenDTO()
        {
            Ordenid = detallesorden.Ordenid,
            Productoid = detallesorden.Productoid,
            Cantidad = detallesorden.Cantidad,
            Precio = detallesorden.Precio,
        };
        return Ok(detallesordenDTO);
    }

    [HttpPost]
    public IActionResult CrearDetallesorden(DetallesordenDTO detDto)
    {
        var detallesorden = new Detallesorden()
        {
            Ordenid = detDto.Ordenid,
            Productoid = detDto.Productoid,
            Cantidad = detDto.Cantidad,
            Precio = detDto.Precio,
        };
        
        _unitOfWork.Detallesordenes.Add(detallesorden);
        _unitOfWork.SaveChanges();
        return Ok("Detalles de orden creadas con exito");
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _unitOfWork.Detallesordenes.Delete(id);
        _unitOfWork.SaveChanges();
        return Ok("Detalles de orden eliminadas con éxito");
    }
}