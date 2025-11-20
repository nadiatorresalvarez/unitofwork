using Lab4_NadiaTorres.Models;
using Lab4_NadiaTorres.Models.DTOS;
using Lab4_NadiaTorres.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_NadiaTorres.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdeneController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdeneController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    public IActionResult ObtenerOrdenes()
    {
        var ordenes = _unitOfWork.Ordenes.GetAll();
        var ordenesDTO = ordenes.Select(c => new OrdeneDTO
        {
            Clienteid = c.Clienteid,
            Total = c.Total,
        }).ToList();
        return Ok(ordenesDTO);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var ordene = _unitOfWork.Ordenes.GetById(id);
        if (ordene == null)
        {
            return NotFound("Orden no encontrado");
        }

        var ordeneDTO = new OrdeneDTO
        {
            Clienteid = ordene.Clienteid,
            Total = ordene.Total,
        };
        return Ok(ordeneDTO);
    }

    [HttpPost]
    public IActionResult CrearOrdene(OrdeneDTO orDto)
    {
        var ordene = new Ordene()
        {
            Clienteid = orDto.Clienteid,
            Total = orDto.Total,
        };
        
        _unitOfWork.Ordenes.Add(ordene);
        _unitOfWork.SaveChanges();
        return Ok("Orden creada con exito");
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _unitOfWork.Ordenes.Delete(id);
        _unitOfWork.SaveChanges();
        return Ok("Orden eliminada con éxito");
    }
}