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
    public class DepositService : BaseService<Deposit>, IDepositService
    {
        private readonly IRepository<Deposit> depositRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepositService(IUnitOfWork unitOfWork, IRepository<Deposit> depositRepository)
                              : base(unitOfWork, depositRepository)
        {
            this.depositRepository = depositRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Deposit> GetDeposit()
        {
            return depositRepository.GetAll();
        }

        public Deposit GetById(Deposit id)
        {
            return depositRepository.GetById(id);
        }

        public void Insert(Deposit deposit)
        {
            depositRepository.Insert(deposit);
        }

        public void Delete(int id)
        {
            depositRepository.Delete(id);
        }

        public void Update(Deposit deposit)
        {
            depositRepository.Update(deposit);
        }


    }
}
