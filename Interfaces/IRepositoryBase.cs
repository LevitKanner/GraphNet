using System.Linq.Expressions;

namespace GraphNet.Interfaces;

public interface IRepositoryBase<T>
{
    IQueryable<T> GetAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges);
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
}