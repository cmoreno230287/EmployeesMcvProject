using MvcTest.Models.Employee;
using MvcTest.Services;
using NSubstitute;

namespace MvcTest.Testing
{
    public class EmployeeUnitTest
    {
        [Fact]
        public async void Should_CalculateAnualSalary_Successfully()
        {
            var employeeService = NSubstitute.Substitute.For<IEmployeeService>();
            var employeesData = new EmployeesData(employeeService);
            var InputValue = GetFakeData(); 
            var ExpectedValue = GetFakeDataExpected();

            var result = await employeesData.CalculateAnualSalaryAsync(InputValue);

            for (int i = 0; i < result.data.Length; i++)
            {
                Assert.True(result.data[i].employee_anualsalary == ExpectedValue.data[i].employee_anualsalary);
            }
        }

        private EmployeeOutput GetFakeData()
        {
            return new EmployeeOutput
            {
                data = new EmployeeViewModel[]
                {
                    new EmployeeViewModel{ id = 1, employee_age = 23, employee_name = "Miguel Suarez", employee_salary = 3000},
                    new EmployeeViewModel{ id = 2, employee_age = 26, employee_name = "Maria Suarez", employee_salary = 4000}
                }
            };
        }

        private EmployeeOutput GetFakeDataExpected()
        {
            return new EmployeeOutput
            {
                data = new EmployeeViewModel[]
                {
                    new EmployeeViewModel{ id = 1, employee_age = 23, employee_name = "Miguel Suarez", employee_salary = 3000, employee_anualsalary = 36000},
                    new EmployeeViewModel{ id = 2, employee_age = 26, employee_name = "Maria Suarez", employee_salary = 4000, employee_anualsalary = 48000}
                }
            };
        }
    }
}