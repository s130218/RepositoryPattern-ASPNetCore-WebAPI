using RepositoryPattern_ASPNetCore_WebAPI.Dto;
using RepositoryPattern_ASPNetCore_WebAPI.Model;

namespace RepositoryPattern_ASPNetCore_WebAPI.Factory;

public class EmployeeFactory : IEmployeeFactory
{
    public Employee MapEmployeeDtoToEntity(EmployeeDto dto)
    {
        Employee entity = new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email,
            Address = dto.Address,
            Designation = dto.Designation
        };
        return entity;
    }

    public Employee MapEmployeeCreateDtoToEntity(EmployeeCreateDto dto)
    {
        Employee entity = new()
        {
            Name = dto.Name,
            Email = dto.Email,
            Address = dto.Address,
            Designation = dto.Designation
        };
        return entity;
    }

    public EmployeeDto MapEmployeeEntityToDto(Employee entity)
    {
        EmployeeDto dto = new();
        {
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Email = entity.Email;
            dto.Designation = entity.Designation;
            dto.Address = entity.Address;
        }
        return dto;
    }

    public List<EmployeeDto> MapAndGetEmployees(List<Employee> entites)
    {
        if (entites == null || entites.Count == 0)
        {
            return new List<EmployeeDto>();
        }

        var results = new List<EmployeeDto>();

        foreach (var item in entites)
        {
            results.Add(new EmployeeDto
            {
                Id = item.Id,
                Name = item.Name,
                Email = item.Email,
                Address = item.Address,
                Designation = item.Designation,
            });
        }
        return results;
    }
}
