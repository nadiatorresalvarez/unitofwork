using Lab4_NadiaTorres.Models;
using Lab4_NadiaTorres.Models.DTOS;
using Lab4_NadiaTorres.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_NadiaTorres.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriaController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult ObtenerCategorias()
    {
        var categorias = _unitOfWork.Categorias.GetAll();
        var categoriasDTO = categorias.Select(c => new CategoriaDTO
        {
            Nombre = c.Nombre,
        }).ToList();
        return Ok(categoriasDTO);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var categoria = _unitOfWork.Categorias.GetById(id);
        if (categoria == null)
        {
            return NotFound("Categoria no encontrado");
        }

        var categoriaDTO = new CategoriaDTO
        {
            Nombre = categoria.Nombre
        };
        return Ok(categoriaDTO);
    }

    [HttpPost]
    public IActionResult CrearCategoria(CategoriaDTO catDto)
    {
        var categoria = new Categoria()
        {
            Nombre = catDto.Nombre
        };
        
        _unitOfWork.Categorias.Add(categoria);
        _unitOfWork.SaveChanges();
        return Ok("Categoria creada con exito");
    }
    
    
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _unitOfWork.Categorias.Delete(id);
        _unitOfWork.SaveChanges();
        return Ok("Categoria eliminada con éxito");
    }
}