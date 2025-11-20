using Lab4_NadiaTorres.Interfaces;
using Lab4_NadiaTorres.Models;

namespace Lab4_NadiaTorres.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly dbContextLab4 _context;
    public IClienteRepository Clientes { get; }
    public IProductoRepository Productos { get; }
    public ICategoriaRepository Categorias { get; }
    public IOrdeneRepository Ordenes { get; }
    public IDetallesordenRepository Detallesordenes { get; }

    public UnitOfWork
        (
            dbContextLab4 context, 
            IClienteRepository clienteRepository, 
            IProductoRepository productoRepository,
            ICategoriaRepository categoriasRepository,
            IOrdeneRepository ordenesRepository,
            IDetallesordenRepository  detallesordenRepository
        )
    {
        _context = context;
        Clientes = clienteRepository;
        Productos = productoRepository;
        Categorias = categoriasRepository;
        Ordenes = ordenesRepository;
        Detallesordenes  = detallesordenRepository;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}