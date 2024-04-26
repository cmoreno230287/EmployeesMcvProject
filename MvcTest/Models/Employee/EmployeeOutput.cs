namespace MvcTest.Models.Employee
{
    public class EmployeeOutput
    {
        public string status { get; set; }
        public string message { get; set; }
        public EmployeeViewModel[] data { get; set; }
    }
}
