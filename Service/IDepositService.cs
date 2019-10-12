using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service
{
    public interface IDepositService
    {
        IEnumerable<Deposit> GetCustomers();
        Deposit GetById(Deposit id);
        void Update(Deposit deposit);
        void Delete(Deposit deposit);
        //void Save();
    }
}
