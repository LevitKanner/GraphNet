using GraphNet.Interfaces;

namespace GraphNet.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly ApplicationContext _context;

    public ProductRepository(ApplicationContext context)
    {
        _context = context;
    }
}