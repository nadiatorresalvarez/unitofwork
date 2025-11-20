using Lab4_NadiaTorres.Models;

namespace Lab4_NadiaTorres.Interfaces;

public interface IDetallesordenRepository
{
    Detallesorden GetById(int id);
    IEnumerable<Detallesorden> GetAll();
    void Add(Detallesorden detallesorden);
    void Update(Detallesorden detallesorden);
    void Delete(int id);
    
}