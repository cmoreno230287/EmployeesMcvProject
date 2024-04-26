using Microsoft.AspNetCore.Mvc;
using RestSharp.Authenticators;
using RestSharp;
using System.Threading;
using MvcTest.Models.Employee;
using MvcTest.Services;

namespace MvcTest.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService = null;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            //var response = await new EmployeesData(_employeeService).GetEmployeesAsync(id);

            return View("EmployeeList");
        }

        [HttpPost]
        public async Task<IActionResult> GetEmployees(int? id)
        {
            var response = await new EmployeesData(_employeeService).GetEmployeesAsync(id);

            return Json(response);
        }
    }
}
