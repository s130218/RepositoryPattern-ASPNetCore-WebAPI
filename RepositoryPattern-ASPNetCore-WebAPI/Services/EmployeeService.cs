using RepositoryPattern_ASPNetCore_WebAPI.Model;
using RepositoryPattern_ASPNetCore_WebAPI.Repositories.EmployeeRepo;

namespace RepositoryPattern_ASPNetCore_WebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        #region Ctor & Properties
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #endregion

        #region Method

        public async Task<ServiceResult<Employee>> AddEmployeAsync(Employee entity)
        {
            var isExist = await _employeeRepository.GetAsync(x => x.Email == entity.Email).ConfigureAwait(false);

            if (isExist != null)
                return ServiceResult<Employee>.Fail("Record Already Exist");

            await _employeeRepository.AddAsync(entity).ConfigureAwait(false);
            await _employeeRepository.CommitAsync().ConfigureAwait(false);

            return ServiceResult<Employee>.Success("New Record Added Successfully");
        }

        public async Task<ServiceResult<Employee>> GetEmployeeByIdAsync(int employeeId)
        {
            var data = await _employeeRepository.GetByIdAsync(employeeId).ConfigureAwait(false);

            if (data == null)
                return ServiceResult<Employee>.Fail("Record Not Found");

            return new ServiceResult<Employee>(true) { Data = data };
        }

        public async Task<ServiceResult<List<Employee>>> GetAllEmployeeAsync()
        {
            var response = await _employeeRepository.GetAllAsync().ConfigureAwait(false);
            var data = response.ToList();

            if (data == null)
                return ServiceResult<List<Employee>>.Fail("Record Not Found");

            return new ServiceResult<List<Employee>>(true) { Data = data };
        }


        public async Task<ServiceResult<Employee>> UpdateEmployeeAsync(Employee entity)
        {
            var response = await _employeeRepository.GetByIdAsNoTrackingAsync(entity.Id).ConfigureAwait(false);
            if (response == null)
                return ServiceResult<Employee>.Fail("Record Not Found");

            _employeeRepository.Update(entity);
            await _employeeRepository.CommitAsync().ConfigureAwait(false);

            return ServiceResult<Employee>.Success("Record Edited Successfully");
        }


        public async Task<ServiceResult> DeleteEmployeeAsync(int employeeId)
        {
            var entity = await _employeeRepository.GetByIdAsync(employeeId).ConfigureAwait(false);

            if (entity == null)
                return ServiceResult.Fail("Record Not Found");

            _employeeRepository.Delete(entity);
            await _employeeRepository.CommitAsync().ConfigureAwait(false);

            return ServiceResult.Success("Record Deleted Successfully");
        }

        #endregion
    }
}
