using BirthdayService;
using RealmService;
using System;
using System.Linq;


namespace BirthdayServiceImplementation
{
    public class BirthdayWishesService : IBirthdayWishesService
    {
        IEmployees _employees;
        public BirthdayWishesService(IEmployees employees)
        {
            _employees = employees;
        }
        public string getEmployeeBirthday()
        {
            string message = "Happy Birthday ";
            int birthdayCount = 0;
            var employeeBirthdayList = _employees.getEmployeeList();
            var doNotSendWishesEmployees = _employees.getDoNotSendWishesList();

            foreach (var employee in employeeBirthdayList)
            {
                var dateOfBirth = Convert.ToDateTime(employee.dateOfBirth).Date;
                var stardDate = Convert.ToDateTime(employee.employmentStartDate).Date;
                var lastNotification = Convert.ToDateTime(employee.lastNotification);
                if (dateOfBirth == DateTime.Now.Date && !doNotSendWishesEmployees.Contains(employee.id) && stardDate <= DateTime.Now.Date && lastNotification <= DateTime.Now.Date)
                {
                    message += employee.name + ", ";
                    ++birthdayCount;
                }               
            }
            message = birthdayCount > 0 ? message.Remove(message.Length - 2): message;
            return birthdayCount > 0 ? message : "";
        }
    }

    
}