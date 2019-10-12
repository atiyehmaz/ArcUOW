using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Repsitory;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<Employee> employeeRepository;
        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void Delete(Employee employee)
        {
            employeeRepository.Delete(employee);
        }

        public Employee GetById(Employee id)
        {
            return employeeRepository.GetById(id);
        }

        public IEnumerable<Employee> GetCustomers()
        {
            return employeeRepository.GetAll();
        }

        public void Insert(Employee employee)
        {
            employeeRepository.Insert(employee);
        }

        //public void Save()
        //{
        //    employeeRepository.Save();
        //}

        public void Update(Employee employee)
        {
            employeeRepository.Update(employee);
        }
    }
}
