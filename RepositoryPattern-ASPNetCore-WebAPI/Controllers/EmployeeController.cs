using Microsoft.AspNetCore.Mvc;
using RepositoryPattern_ASPNetCore_WebAPI.Dto;
using RepositoryPattern_ASPNetCore_WebAPI.Factory;
using RepositoryPattern_ASPNetCore_WebAPI.Services;

namespace RepositoryPattern_ASPNetCore_WebAPI.Controllersl;

[Route("v1/")]
[ApiController]
public class EmployeeController : Controller
{
    #region Ctor & Properties
    private readonly IEmployeeService _employeeService;
    private readonly IEmployeeFactory _employeeFactory;
    public EmployeeController(IEmployeeService employeeService, IEmployeeFactory employeeFactory)
    {
        _employeeService = employeeService;
        _employeeFactory = employeeFactory;
    }

    #endregion

    #region Method
    /// <summary>
    /// Create Employee
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Route("employee")]
    [HttpPost]
    public async Task<ActionResult> AddEmployeeAsync([FromBody] EmployeeCreateDto dto)
    {
        var mappedData = _employeeFactory.MapEmployeeCreateDtoToEntity(dto);
        var response = await _employeeService.AddEmployeAsync(mappedData).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Get Employee
    /// </summary>
    /// <param name="employeeId"></param>
    /// <returns></returns>
    [Route("employee/{employeeId}")]
    [HttpGet]
    public async Task<ActionResult<EmployeeDto>> GetAllAsync(int employeeId)
    {
        var response = await _employeeService.GetEmployeeByIdAsync(employeeId).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Get All Employee
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Route("employee")]
    [HttpGet]
    public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployeeAsync()
    {
        var result = await _employeeService.GetAllEmployeeAsync().ConfigureAwait(false);

        if (result.Status)
        {
            var dto = _employeeFactory.MapAndGetEmployees(result.Data);
            return Ok(dto);
        }
        return Ok(result);
    }

    /// <summary>
    /// Edit Employee
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Route("employee")]
    [HttpPut]
    public async Task<ActionResult> UpdateEmployeeAsync([FromBody] EmployeeDto dto)
    {
        var response = await _employeeService.GetEmployeeByIdAsync(dto.Id).ConfigureAwait(false);
        if (response.Status)
        {
            var mappedData = _employeeFactory.MapEmployeeDtoToEntity(dto);
            var updateResponse = await _employeeService.UpdateEmployeeAsync(mappedData).ConfigureAwait(false);
            return Ok(updateResponse);
        }
        return Ok(response);
    }

    /// <summary>
    /// Delete Employee 
    /// <param name="employeeId"></param>
    /// <returns></returns>
    [Route("employee/{employeeId}")]
    [HttpDelete]
    public async Task<ActionResult> DeleteUserAsync(int employeeId)
    {
        var users = await _employeeService.DeleteEmployeeAsync(employeeId).ConfigureAwait(false);
        return Ok(users);
    }

    #endregion


}
