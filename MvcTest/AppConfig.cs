namespace MvcTest
{
    public class AppConfig
    {
        private readonly IConfiguration _configuration = null;
        public string GetEmployeesEndPoint { get; set; }
        public string GetEmployeeByIdEndPoint { get; set; }
        public string ExampleApiBaseUrl { get; set; }
        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
            ExampleApiBaseUrl = _configuration.GetValue<string>("ThirdPartyAPI:ExampleApi:BaseUrl");
            GetEmployeesEndPoint = _configuration.GetValue<string>("ThirdPartyAPI:ExampleApi:Endpoints:GetEmployees");
            GetEmployeeByIdEndPoint = _configuration.GetValue<string>("ThirdPartyAPI:ExampleApi:Endpoints:GetEmployeeById");
        }
    }
}
