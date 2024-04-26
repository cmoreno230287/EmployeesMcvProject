using MvcTest.Services;

namespace MvcTest.Models.Employee
{
    public class EmployeesData
    {
        private readonly IEmployeeService _employeeService = null;
        public EmployeesData(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<EmployeeOutput?> GetEmployeesAsync(int? Id)
        {
            EmployeeOutput Result = await _employeeService.GetEmployeesAsync(Id);
            return await CalculateAnualSalaryAsync(Result);
        }

        public async Task<EmployeeOutput?> CalculateAnualSalaryAsync(EmployeeOutput employeeOutput)
        {
            EmployeeOutput Result = employeeOutput;
            if (Result.data != null)
            {
                foreach (var item in Result.data)
                {
                    item.employee_anualsalary = item.employee_salary * 12;
                }
            }
            return Result;
        }
    }
}
