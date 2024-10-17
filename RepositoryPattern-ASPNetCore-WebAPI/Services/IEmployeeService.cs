using RepositoryPattern_ASPNetCore_WebAPI.Model;

namespace RepositoryPattern_ASPNetCore_WebAPI.Services;

public interface IEmployeeService
{
    Task<ServiceResult<Employee>> AddEmployeAsync(Employee entity);
    Task<ServiceResult<Employee>> GetEmployeeByIdAsync(int id);
    Task<ServiceResult<List<Employee>>> GetAllEmployeeAsync();
    Task<ServiceResult<Employee>> UpdateEmployeeAsync(Employee entity);
    Task<ServiceResult> DeleteEmployeeAsync(int employeeId);
}
