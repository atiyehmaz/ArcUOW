using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service
{
    public interface IBranchService
    {
        IEnumerable<Branch> GetCustomers();
        Branch GetById(Branch id);
        void Insert(Branch branch);
        void Update(Branch branch);
        void Delete(Branch branch);
       // void Save();
    }
}
