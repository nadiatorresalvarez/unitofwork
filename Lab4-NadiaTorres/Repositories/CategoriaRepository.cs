using Lab4_NadiaTorres.Interfaces;
using Lab4_NadiaTorres.Models;

namespace Lab4_NadiaTorres.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly dbContextLab4 _context;

    public CategoriaRepository(dbContextLab4 context)
    {
        _context = context;
    }
    
    public Categoria GetById(int id)
    {
        return _context.Set<Categoria>().Find(id);
    }

    public IEnumerable<Categoria> GetAll()
    {
        return _context.Set<Categoria>().ToList();
    }

    public void Add(Categoria categoria)
    {
        _context.Set<Categoria>().Add(categoria);
    }

    public void Update(Categoria categoria)
    {
        _context.Set<Categoria>().Update(categoria);
    }

    public void Delete(int id)
    {
        var categoria = _context.Set<Categoria>().Find(id);
        if (categoria != null)
        {
            _context.Set<Categoria>().Remove(categoria);
        }
    }
}