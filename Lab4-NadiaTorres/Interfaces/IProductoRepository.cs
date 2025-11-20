using Lab4_NadiaTorres.Models;

namespace Lab4_NadiaTorres.Interfaces;

public interface IProductoRepository
{
    Producto GetById(int id);
    IEnumerable<Producto> GetAll();
    void Add(Producto producto);
    void Update(Producto producto);
    void Delete(int id);
    
}