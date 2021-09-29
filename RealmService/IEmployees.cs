using RealmServiceImplementation.Models;
using System.Collections.Generic;

namespace RealmService
{
    public interface IEmployees
    {
        List<Employee> getEmployeeList();
        int[] getDoNotSendWishesList();
    }
}
