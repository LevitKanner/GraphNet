using GraphNet.Entities;
using GraphNet.Entities.Models;

namespace GraphNet.Interfaces;

public interface ICategoryRepository
{
    IEnumerable<Category> GetAllCategoriesAsync();
    Task<Category?> GetCategoryById(int id);
    Task<Category> UpdateCategoryAsync(int id, Category update);
    Task<Category> DeleteCategoryAsync(int id);
}