namespace RepositoryPattern_ASPNetCore_WebAPI.Repositories.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    Task CommitAsync();
}
