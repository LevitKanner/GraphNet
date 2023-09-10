using System.Linq.Expressions;
using GraphNet.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraphNet.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly ApplicationContext _context;

    public RepositoryBase(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges)
    {
        return trackChanges
            ? _context.Set<T>().Where(condition).AsTracking()
            : _context.Set<T>().Where(condition).AsNoTracking();
    }

    public T Create(T entity)
    {
        return _context.Set<T>().Add(entity).Entity;
    }

    public T Update(T entity)
    {
        return _context.Set<T>().Update(entity).Entity;
    }

    public T Delete(T entity)
    {
        return _context.Set<T>().Remove(entity).Entity;
    }
}