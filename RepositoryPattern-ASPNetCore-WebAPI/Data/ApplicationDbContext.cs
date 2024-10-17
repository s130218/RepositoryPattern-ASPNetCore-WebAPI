using Microsoft.EntityFrameworkCore;
using RepositoryPattern_ASPNetCore_WebAPI.Model;

namespace RepositoryPattern_ASPNetCore_WebAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Employee> Employees { get; set; }

}
