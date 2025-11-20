using Lab4_NadiaTorres.Interfaces;
using Lab4_NadiaTorres.Models;

namespace Lab4_NadiaTorres.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly dbContextLab4 _context;

    public ClienteRepository(dbContextLab4 context)
    {
        _context = context;
    }

    public Cliente GetById(int id)
    {
        return _context.Set<Cliente>().Find(id);
    }

    public IEnumerable<Cliente> GetAll()
    {
        return _context.Set<Cliente>().ToList();
    }

    public void Add(Cliente cliente)
    {
        _context.Set<Cliente>().Add(cliente);
    }

    public void Update(Cliente cliente)
    {
        _context.Set<Cliente>().Update(cliente);
    }

    public void Delete(int id)
    {
        var cliente = _context.Set<Cliente>().Find(id);
        if (cliente != null)
        {
            _context.Set<Cliente>().Remove(cliente);
        }
    }
}