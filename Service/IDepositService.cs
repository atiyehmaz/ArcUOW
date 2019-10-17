using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Service.BaseService;

namespace Service
{
    public interface IDepositService: IBaseService<Deposit>
    {
        IEnumerable<Deposit> GetAll();

        Deposit GetById(Deposit id);

        void Insert(Deposit deposit);


        void Update(Deposit deposit);

        void Delete(int id);
    }
}
