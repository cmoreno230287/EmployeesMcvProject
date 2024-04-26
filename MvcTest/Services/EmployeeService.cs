using Microsoft.Extensions.Configuration;
using MvcTest.Models.Employee;
using RestSharp;

namespace MvcTest.Services
{
    public class EmployeeService: IEmployeeService
    {
        //private readonly AppConfig _appConfig;
        public string _getEmployeesEndPoint { get; set; }
        public string _getEmployeeByIdEndPoint { get; set; }
        public string _exampleApiBaseUrl { get; set; }
        public EmployeeService(IConfiguration configuration) 
        {
            //_appConfig = new AppConfig(configuration.GetSection("ThirdPartyAPI"));
            _exampleApiBaseUrl = configuration.GetValue<string>("ThirdPartyAPI:ExampleApi:BaseUrl");
            _getEmployeesEndPoint = configuration.GetValue<string>("ThirdPartyAPI:ExampleApi:Endpoints:GetEmployees");
            _getEmployeeByIdEndPoint = configuration.GetValue<string>("ThirdPartyAPI:ExampleApi:Endpoints:GetEmployeeById");
        }

        public async Task<EmployeeOutput?> GetEmployeesAsync(int? Id)
        {
            string endpoint = (Id == null) ? _getEmployeesEndPoint : _getEmployeeByIdEndPoint.Replace("{id}", Id.ToString());

            var options = new RestClientOptions(_exampleApiBaseUrl);
            var client = new RestClient(options);
            var request = new RestRequest(endpoint);
            var response = await client.GetAsync<EmployeeOutput>(request);
            
            return response;
        }
    }
}
