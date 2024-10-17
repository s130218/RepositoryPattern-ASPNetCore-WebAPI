using RepositoryPattern_ASPNetCore_WebAPI.Data;

namespace RepositoryPattern_ASPNetCore_WebAPI.Repositories.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    protected readonly ApplicationDbContext _db;

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
    }

    public void Commit()
    {
        _db.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}
