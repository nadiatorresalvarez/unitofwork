using Lab4_NadiaTorres.Interfaces;
using Lab4_NadiaTorres.Models;

namespace Lab4_NadiaTorres.Repositories;

public class DetallesordenRepository : IDetallesordenRepository
{
    private readonly dbContextLab4 _context;

    public DetallesordenRepository(dbContextLab4 context)
    {
        _context = context;
    }
    
    public Detallesorden GetById(int id)
    {
        return _context.Set<Detallesorden>().Find(id);
    }

    public IEnumerable<Detallesorden> GetAll()
    {
        return _context.Set<Detallesorden>().ToList();
    }

    public void Add(Detallesorden detallesorden)
    {
        _context.Set<Detallesorden>().Add(detallesorden);
    }

    public void Update(Detallesorden detallesorden)
    {
        _context.Set<Detallesorden>().Update(detallesorden);
    }

    public void Delete(int id)
    {
        var detallesorden = _context.Set<Detallesorden>().Find(id);
        if (detallesorden != null)
        {
            _context.Set<Detallesorden>().Remove(detallesorden);
        }
    }
}