using Lab4_NadiaTorres.Models;
using Lab4_NadiaTorres.Models.DTOS;
using Microsoft.AspNetCore.Mvc;
using Lab4_NadiaTorres.UnitOfWork;

namespace Lab4_NadiaTorres.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ClienteController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public IActionResult CrearCliente(ClienteDTO cliDto)
    {
        var cliente = new Cliente()
        {
            Nombre = cliDto.Nombre,
            Correo = cliDto.Correo,
            Fechacreacion = DateTime.Now
        };
        
        
        _unitOfWork.Clientes.Add(cliente);
        _unitOfWork.SaveChanges();
        return Ok("cliente creado con exito");
    }

    [HttpGet]
    public IActionResult ObtenerClientes()
    {
        var clientes = _unitOfWork.Clientes.GetAll();
        var clientesDTO = clientes.Select(c => new ClienteDTO
        {
            Nombre = c.Nombre,
            Correo = c.Correo,
        }).ToList();
        return Ok(clientesDTO);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var cliente = _unitOfWork.Clientes.GetById(id);
        if (cliente == null)
        {
            return NotFound("Cliente no encontrado");
        }

        var clienteDTO = new ClienteDTO
        {
            Nombre = cliente.Nombre,
            Correo = cliente.Correo,
        };
        return Ok(clienteDTO);
    }

    [HttpPut]
    public IActionResult UpdateCliente(int id, [FromBody] ClienteDTO clienteDto)
    {
        var cliente = _unitOfWork.Clientes.GetById(id);
        if (cliente == null)
        {
            return NotFound("Cliente no encontrado para actualizar.");
        }
    
        cliente.Nombre = clienteDto.Nombre;
        cliente.Correo = clienteDto.Correo;

        _unitOfWork.Clientes.Update(cliente);
        _unitOfWork.SaveChanges();
    
        return Ok("Cliente actualizado con éxito");
    }

    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _unitOfWork.Clientes.Delete(id);
        _unitOfWork.SaveChanges();
        return Ok("Cliente eliminado con éxito");
    }
}