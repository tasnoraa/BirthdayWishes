using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Configuration;
using RealmService;
using RealmServiceImplementation;
using RealmServiceImplementation.Models;

namespace BirthdayWishes.Tests.RealmServiceImplementationTests
{
    [TestFixture]
    public class EmployeesTests
    {
        [Test]
        public void getEmployeeList_WhenCalled_ReturnEmployees()
        {            
            var json = JsonConvert.SerializeObject(GetEmployees());
            var url  = "https://interview-assessment-1.realmdigital.co.za/employees";
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            httpResponse.Content = new StringContent(json);

            var mockHttpClientWrapper = new Mock<IHttpClientWrapper>();
            mockHttpClientWrapper.Setup(t => t.GetAsync(It.Is<string>(s => s.StartsWith(url))))
                .Returns(httpResponse);

            Employees employees = new Employees(mockHttpClientWrapper.Object);

            ConfigurationManager.AppSettings["EmployeesApiBaseAddress"] = "https://interview-assessment-1.realmdigital.co.za/employees";

            var result = employees.getEmployeeList();
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void getEmployeeList_EmptyEmployees_ReturnNoEmployees()
        {
            var json = JsonConvert.SerializeObject(EmptyEmployees());
            var url = "https://interview-assessment-1.realmdigital.co.za/employees";
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            httpResponse.Content = new StringContent(json);

            var mockHttpClientWrapper = new Mock<IHttpClientWrapper>();
            mockHttpClientWrapper.Setup(t => t.GetAsync(It.Is<string>(s => s.StartsWith(url))))
                .Returns(httpResponse);

            Employees employees = new Employees(mockHttpClientWrapper.Object);

            ConfigurationManager.AppSettings["EmployeesApiBaseAddress"] = "https://interview-assessment-1.realmdigital.co.za/employees";

            var result = employees.getEmployeeList();
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void getDoNotSendWishesList_EmptyDoNotSendList_ReturnNoEmployees()
        {
            var json = JsonConvert.SerializeObject(doNotSentEmptyList());
            var url = "https://interview-assessment-1.realmdigital.co.za/employees";
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            httpResponse.Content = new StringContent(json);

            var mockHttpClientWrapper = new Mock<IHttpClientWrapper>();
            mockHttpClientWrapper.Setup(t => t.GetAsync(It.Is<string>(s => s.StartsWith(url))))
                .Returns(httpResponse);

            Employees employees = new Employees(mockHttpClientWrapper.Object);

            ConfigurationManager.AppSettings["DoNotSendWishesApiBaseAddress"] = "https://interview-assessment-1.realmdigital.co.za/employees";

            var result = employees.getDoNotSendWishesList();
            Assert.That(result.Length, Is.EqualTo(0));
        }

        [Test]
        public void getDoNotSendWishesList_EmptyDoNotSendList_ReturnDoNotSendList()
        {
            var json = JsonConvert.SerializeObject(doNotSentList());
            var url = "https://interview-assessment-1.realmdigital.co.za/employees";
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            httpResponse.Content = new StringContent(json);

            var mockHttpClientWrapper = new Mock<IHttpClientWrapper>();
            mockHttpClientWrapper.Setup(t => t.GetAsync(It.Is<string>(s => s.StartsWith(url))))
                .Returns(httpResponse);

            Employees employees = new Employees(mockHttpClientWrapper.Object);

            ConfigurationManager.AppSettings["DoNotSendWishesApiBaseAddress"] = "https://interview-assessment-1.realmdigital.co.za/employees";

            var result = employees.getDoNotSendWishesList();
            Assert.That(result, Does.Contain(256));
            Assert.That(result, Does.Contain(584));
        }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    id = 294,
                    name = "Bari",
                    lastname = "Somma",
                    dateOfBirth = DateTime.Now.ToString(),
                    employmentStartDate = "2014-06-01T00:00:00"
                },
                new Employee()
                {
                    id = 279,
                    name = "Evita",
                    lastname = "Hardge",
                    dateOfBirth = DateTime.Now.ToString(),
                    employmentStartDate = "2014-06-01T00:00:00"
                }

            };

        }
        public List<Employee> EmptyEmployees()
        {
            return new List<Employee>(); 
        }

        public int[] doNotSentEmptyList()
        {
            return Array.Empty<int>();
        }

        public int[] doNotSentList()
        {
            return new int[] { 256, 584};
        }
    }
}
