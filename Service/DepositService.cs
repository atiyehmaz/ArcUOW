using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Repsitory;

namespace Service
{
    public class DepositService : IDepositService
    {
        private IRepository<Deposit> depositRepository;

        public DepositService(IRepository<Deposit> depositRepository)
        {
            this.depositRepository = depositRepository;
        }
        public void Delete(Deposit deposit)
        {
            depositRepository.Delete(deposit);
        }

        public Deposit GetById(Deposit id)
        {
            return depositRepository.GetById(id);
        }

        public IEnumerable<Deposit> GetCustomers()
        {
            return depositRepository.GetAll();
        }

        //public void Save()
        //{
        //    depositRepository.Save();
        //}

        public void Update(Deposit deposit)
        {
            depositRepository.Update(deposit);
        }
    }
}
