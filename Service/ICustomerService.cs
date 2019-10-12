using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Service.BaseService;

namespace Service
{
    public interface ICustomerService : IBaseService<Customer>
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(Customer id);
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);

        //void Save();
    }
}
