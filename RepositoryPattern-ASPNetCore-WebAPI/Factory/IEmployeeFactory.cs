using RepositoryPattern_ASPNetCore_WebAPI.Dto;
using RepositoryPattern_ASPNetCore_WebAPI.Model;

namespace RepositoryPattern_ASPNetCore_WebAPI.Factory;

public interface IEmployeeFactory
{
    Employee MapEmployeeCreateDtoToEntity(EmployeeCreateDto dto);
    Employee MapEmployeeDtoToEntity(EmployeeDto dto);
    EmployeeDto MapEmployeeEntityToDto(Employee entity);
    List<EmployeeDto> MapAndGetEmployees(List<Employee> entites);
}
