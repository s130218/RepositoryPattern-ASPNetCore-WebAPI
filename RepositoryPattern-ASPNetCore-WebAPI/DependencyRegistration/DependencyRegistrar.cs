using RepositoryPattern_ASPNetCore_WebAPI.Factory;
using RepositoryPattern_ASPNetCore_WebAPI.Repositories.EmployeeRepo;
using RepositoryPattern_ASPNetCore_WebAPI.Repositories.GenericRepository;
using RepositoryPattern_ASPNetCore_WebAPI.Repositories.UnitOfWorks;
using RepositoryPattern_ASPNetCore_WebAPI.Services;

namespace RepositoryPattern_ASPNetCore_WebAPI.DependencyRegistration;

public class DependencyRegistrar
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        //Common
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

        //Repository
        services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));

        //Service
        services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));

        //Factory
        services.AddScoped(typeof(IEmployeeFactory), typeof(EmployeeFactory));
    }
}
