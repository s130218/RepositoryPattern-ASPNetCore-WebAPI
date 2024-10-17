using RepositoryPattern_ASPNetCore_WebAPI.Model;
using RepositoryPattern_ASPNetCore_WebAPI.Repositories.GenericRepository;

namespace RepositoryPattern_ASPNetCore_WebAPI.Repositories.EmployeeRepo;

public interface IEmployeeRepository : IRepository<Employee>
{
}
