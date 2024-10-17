using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPattern_ASPNetCore_WebAPI.Model;

[Table("Employee")]
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string  Address { get; set; }
    public string Designation { get; set; }
}
