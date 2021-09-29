using BirthdayServiceImplementation;
using Moq;
using NUnit.Framework;
using RealmService;
using RealmServiceImplementation.Models;
using System;
using System.Collections.Generic;

namespace BirthdayWishes.Tests.BirthdayService
{
    [TestFixture]
    public class BirthdayWishesTests
    {
        BirthdayWishesService _birthdayWishesService;
        Mock<IEmployees> _employees;
        [SetUp]
        public void setup()
        {
            _employees = new Mock<IEmployees>();
            _birthdayWishesService = new BirthdayWishesService(_employees.Object);
        }
        [Test]
        public void getEmployeeBirthday_NoWishes_EmptyString()
        {
            int[] emptyArray = Array.Empty<int>();
            List<Employee> emptyList = new List<Employee>();
            _employees.Setup(em => em.getDoNotSendWishesList()).Returns(emptyArray);
            _employees.Setup(em => em.getEmployeeList()).Returns(emptyList);
            var result = _birthdayWishesService.getEmployeeBirthday();
            Assert.That(result, Is.EqualTo(String.Empty));
        }

        [Test]
        public void getEmployeeBirthday_WhenCalled_ReturnBirthday()
        {
            int[] emptyArray = Array.Empty<int>();
            List<Employee> employeeList = new List<Employee>();
            Employee employee = new Employee();
            employee = getEmployee();
            employeeList.Add(employee);
            _employees.Setup(em => em.getDoNotSendWishesList()).Returns(emptyArray);
            _employees.Setup(em => em.getEmployeeList()).Returns(employeeList);
            var result = _birthdayWishesService.getEmployeeBirthday();
            Assert.That(result, Is.EqualTo("Happy Birthday Evita"));
        }

        [Test]
        public void getEmployeeBirthday_DoNotSendWishes_ReturnEmptyWishes()
        {
            int[] emptyArray = doNotSentWishes();
            List<Employee> employeeList = new List<Employee>();
            Employee employee = new Employee();
            employee = getEmployee();
            employeeList.Add(employee);
            _employees.Setup(em => em.getDoNotSendWishesList()).Returns(emptyArray);
            _employees.Setup(em => em.getEmployeeList()).Returns(employeeList);
            var result = _birthdayWishesService.getEmployeeBirthday();
            Assert.That(result, Is.EqualTo(String.Empty));
        }

        [Test]
        public void getEmployeeBirthday_SendWishes_ReturnMultipleWishes()
        {
            int[] emptyArray = Array.Empty<int>();
            List<Employee> employeeList = new List<Employee>();
            Employee employee, employee2 = new Employee();
            employee = getEmployee();
            employee2 = getEmployee2();
            employeeList.Add(employee);
            employeeList.Add(employee2);
            _employees.Setup(em => em.getDoNotSendWishesList()).Returns(emptyArray);
            _employees.Setup(em => em.getEmployeeList()).Returns(employeeList);
            var result = _birthdayWishesService.getEmployeeBirthday();
            Assert.That(result, Is.EqualTo("Happy Birthday Evita, Keena"));
        }

        public Employee getEmployee()
        {
            return new Employee()
            {
                id = 279,
                name = "Evita",
                lastname = "Hardge",
                dateOfBirth = DateTime.Now.ToString(),
                employmentStartDate = "2014-06-01T00:00:00"
            };
        }

        public Employee getEmployee2()
        {
            return new Employee()
            {
                id = 280,
                name = "Keena",
                lastname = "Wehner",
                dateOfBirth = DateTime.Now.ToString(),
                employmentStartDate = "2014-06-01T00:00:00"
            };
        }

        public int[] doNotSentWishes()
        {
            return new int[] { 279 };
        }

    }
}
