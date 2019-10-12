using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Repsitory;
using Data;
using Service.BaseService;

namespace Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork, IRepository<Customer> customerRepository)
                              :base( unitOfWork, customerRepository)
        {
            this._unitOfWork = unitOfWork;
            this.customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customerRepository.GetAll();
        }

        public Customer GetById(Customer id)
        {
            return customerRepository.GetById(id);
        }
        
        public void Insert(Customer customer)
        {
            customerRepository.Insert(customer);
        }

        public new void Delete(Customer customer)
        {
            customerRepository.Delete(customer);
        }

        //public void Save()
        //{
        //    customerRepository.Save();
        //}

        public new void Update(Customer customer)
        {
            customerRepository.Update(customer);
        }

       
    }
}
