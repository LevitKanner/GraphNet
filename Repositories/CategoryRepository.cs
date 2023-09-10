using GraphNet.Entities.Exceptions;
using GraphNet.Entities.Models;
using GraphNet.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraphNet.Repositories;

public class CategoryRepository : ICategoryRepository, IAsyncDisposable
{
    private readonly ApplicationContext _context;

    public CategoryRepository(IDbContextFactory<ApplicationContext> context)
    {
        _context = context.CreateDbContext();
    }

    public IEnumerable<Category> GetAllCategoriesAsync()
    {
        return _context.Categories.AsEnumerable();
    }

    public async Task<Category?> GetCategoryById(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(category => category.Id == id);
    }

    public Task<Category> UpdateCategoryAsync(int id, Category update)
    {
        var category = GetCategory(id);
        category.Name = update.Name;
        return Task.FromResult(_context.Categories.Update(category).Entity);
    }

    private Category? GetCategory(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category is null) throw new UnprocessableException($"Category with {id}does not exist");
        return category;
    }

    public Task<Category> DeleteCategoryAsync(int id)
    {
        var category = GetCategory(id);
        return Task.FromResult(_context.Categories.Remove(category).Entity);
    }

    public ValueTask DisposeAsync()
    {
        return _context.DisposeAsync();
    }
}