using Lab4_NadiaTorres.Models;

namespace Lab4_NadiaTorres.Interfaces;

public interface IOrdeneRepository
{
    Ordene GetById(int id);
    IEnumerable<Ordene> GetAll();
    void Add(Ordene ordene);
    void Update(Ordene ordene);
    void Delete(int id);
}