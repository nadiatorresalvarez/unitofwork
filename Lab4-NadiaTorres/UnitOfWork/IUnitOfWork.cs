using Lab4_NadiaTorres.Interfaces;

namespace Lab4_NadiaTorres.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IClienteRepository Clientes { get; }
    IProductoRepository Productos { get; }
    ICategoriaRepository Categorias { get; }
    IOrdeneRepository Ordenes { get; }
    IDetallesordenRepository Detallesordenes { get; }
    int SaveChanges();

}