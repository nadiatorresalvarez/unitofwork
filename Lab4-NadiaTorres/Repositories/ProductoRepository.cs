using Lab4_NadiaTorres.Interfaces;
using Lab4_NadiaTorres.Models;

namespace Lab4_NadiaTorres.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly dbContextLab4 _context;

    public ProductoRepository(dbContextLab4 context)
    {
        _context = context;
    }

    public Producto GetById(int id)
    {
        return _context.Set<Producto>().Find(id);
    }

    public IEnumerable<Producto> GetAll()
    {
        return _context.Set<Producto>().ToList();
    }

    public void Add(Producto producto)
    {
        _context.Set<Producto>().Add(producto);
    }

    public void Update(Producto producto)
    {
        _context.Set<Producto>().Update(producto);
    }

    public void Delete(int id)
    {
        var producto = _context.Set<Producto>().Find(id);
        if (producto != null)
        {
            _context.Set<Producto>().Remove(producto);
        }
    }
}