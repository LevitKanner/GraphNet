using AutoMapper;
using GraphNet.Entities.Exceptions;
using GraphNet.Entities.Models;
using GraphNet.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraphNet.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Product> GetAllProductsAsync()
    {
        return _context.Products.AsEnumerable();
    }

    public Task<Product?> GetProductByIdAsync(int id)
    {
        return GetProduct(id);
    }

    private Task<Product?> GetProduct(int id)
    {
        var product = _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product is null) throw new UnprocessableException("Product does not exist");
        return product;
    }

    public async Task<Product?> UpdateProduct(int id, Product product)
    {
        var productToUpdate = await GetProduct(id);
        var update = _mapper.Map(product, productToUpdate);
        return _context.Products.Update(update).Entity;
    }

    public async Task<Product?> DeleteProduct(int id)
    {
        var productToDelete = await GetProduct(id);
        return _context.Products.Remove(productToDelete).Entity;
    }
}