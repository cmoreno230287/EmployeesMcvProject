using MvcTest.Models.Employee;

namespace MvcTest.Services
{
    public interface IEmployeeService
    {
        public Task<EmployeeOutput?> GetEmployeesAsync(int? Id);
    }
}
