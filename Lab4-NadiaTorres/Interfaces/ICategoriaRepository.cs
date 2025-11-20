using Lab4_NadiaTorres.Models;

namespace Lab4_NadiaTorres.Interfaces;

public interface ICategoriaRepository
{
    Categoria GetById(int id);
    IEnumerable<Categoria> GetAll();
    void Add(Categoria categoria);
    void Update(Categoria categoria);
    void Delete(int id);
}