﻿namespace MvcTest.Models.Employee
{
    public class EmployeeViewModel
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public decimal employee_salary { get; set; }
        public decimal employee_anualsalary { get; set; }
        public int employee_age { get; set; }
        public string? profile_image { get; set; }
    }

}
