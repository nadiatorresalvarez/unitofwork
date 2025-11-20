using Lab4_NadiaTorres.Interfaces;
using Lab4_NadiaTorres.Models;

namespace Lab4_NadiaTorres.Repositories;

public class OrdeneRepository  : IOrdeneRepository
{
    private readonly dbContextLab4  _context;

    public OrdeneRepository(dbContextLab4 context)
    {
        _context = context;
    }
    public Ordene GetById(int id)
    {
        return _context.Set<Ordene>().Find(id);
    }

    public IEnumerable<Ordene> GetAll()
    {
        return _context.Set<Ordene>().ToList();
    }

    public void Add(Ordene ordene)
    {
        _context.Set<Ordene>().Add(ordene);
    }

    public void Update(Ordene ordene)
    {
        _context.Set<Ordene>().Update(ordene);
    }

    public void Delete(int id)
    {
        var ordene = _context.Set<Ordene>().Find(id);
        if (ordene != null)
        {
            _context.Set<Ordene>().Remove(ordene);
        }
    }
}