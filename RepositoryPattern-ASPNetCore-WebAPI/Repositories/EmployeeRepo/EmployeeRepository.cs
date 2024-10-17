using RepositoryPattern_ASPNetCore_WebAPI.Data;
using RepositoryPattern_ASPNetCore_WebAPI.Model;
using RepositoryPattern_ASPNetCore_WebAPI.Repositories.GenericRepository;

namespace RepositoryPattern_ASPNetCore_WebAPI.Repositories.EmployeeRepo;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}
