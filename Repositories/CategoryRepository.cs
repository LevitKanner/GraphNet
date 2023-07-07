using GraphNet.Interfaces;

namespace GraphNet.Repositories;

public class CategoryRepository: ICategoryRepository
{
    private readonly ApplicationContext _context;

    public CategoryRepository(ApplicationContext context)
    {
        _context = context;
    }
}