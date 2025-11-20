using Lab4_NadiaTorres.Models;

namespace Lab4_NadiaTorres.Interfaces;

public interface IClienteRepository
{
    Cliente GetById(int id);
    IEnumerable<Cliente> GetAll();
    void Add(Cliente cliente);
    void Update(Cliente cliente);
    void Delete(int id);
}