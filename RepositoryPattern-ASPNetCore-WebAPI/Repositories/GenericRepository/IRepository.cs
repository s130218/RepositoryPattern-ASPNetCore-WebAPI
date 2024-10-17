using RepositoryPattern_ASPNetCore_WebAPI.Repositories.UnitOfWorks;
using System.Linq.Expressions;

namespace RepositoryPattern_ASPNetCore_WebAPI.Repositories.GenericRepository;

public interface IRepository<T>: IUnitOfWork where T : class
{
    Task AddAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<T> GetByIdAsNoTrackingAsync(int id);
    Task<T> GetAsync(Expression<Func<T, bool>> where);
    Task<IEnumerable<T>> GetAllAsync();
    void Delete(T entity);
    void Update(T entity);
}
