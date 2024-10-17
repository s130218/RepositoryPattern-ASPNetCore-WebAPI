using Microsoft.EntityFrameworkCore;
using RepositoryPattern_ASPNetCore_WebAPI.Data;
using RepositoryPattern_ASPNetCore_WebAPI.Repositories.UnitOfWorks;
using System.Linq.Expressions;

namespace RepositoryPattern_ASPNetCore_WebAPI.Repositories.GenericRepository;

public class Repository<T> : UnitOfWork, IRepository<T> where T : class
{
    #region Ctor & Properties

    private readonly DbSet<T> _dbSet;
    public Repository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    #endregion


    #region Implementation

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity).ConfigureAwait(false);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id).ConfigureAwait(false);
    }

    public async Task<T> GetByIdAsNoTrackingAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
            _db.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync().ConfigureAwait(false);
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> where)
    {
        return await _dbSet.Where(where).FirstOrDefaultAsync();
    }

    public void Update(T entity)
    {
        _db.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }


    #endregion
}
