using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service
{
    public interface IEmployeeService
    {

        IEnumerable<Employee> GetCustomers();
        Employee GetById(Employee id);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        //void Save();
    }
}
