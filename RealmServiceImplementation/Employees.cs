using Newtonsoft.Json;
using RealmService;
using RealmServiceImplementation.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

namespace RealmServiceImplementation
{
    public class Employees : IEmployees
    {
        private IHttpClientWrapper _client;
        public Employees(IHttpClientWrapper httpClient)
        {
            _client = httpClient;
        }
        public List<Employee> getEmployeeList()
        {
            var employeesApiBaseAddress = ConfigurationManager.AppSettings["EmployeesApiBaseAddress"];
            var employees = new List<Employee>();

            var response =  _client.GetAsync(employeesApiBaseAddress);  
            if (response.IsSuccessStatusCode)
            {
                var jsonData = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<Employee>>(jsonData);
            }

            return employees;
        }

        public int[] getDoNotSendWishesList()
        {
            var doNotSendWishesApiBaseAddress = ConfigurationManager.AppSettings["DoNotSendWishesApiBaseAddress"];
            HttpResponseMessage response = _client.GetAsync(doNotSendWishesApiBaseAddress);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = response.Content.ReadAsStringAsync().Result;
                var wishes = JsonConvert.DeserializeObject<int[]>(jsonData);
                return wishes;
            }

            return null;
        }
    }
}