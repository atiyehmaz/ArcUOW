using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Repsitory;

namespace Service
{
    public class BranchService : IBranchService
    {
        private IRepository<Branch> branchRepository;
        public BranchService(IRepository<Branch> branchRepository)
        {
            this.branchRepository = branchRepository;
        }
        public void Delete(Branch branch)
        {
            branchRepository.Delete(branch);
        }

        public Branch GetById(Branch id)
        {
            return branchRepository.GetById(id);
        }

        public IEnumerable<Branch> GetCustomers()
        {
            return branchRepository.GetAll();
        }

        public void Insert(Branch branch)
        {
            branchRepository.Insert(branch);
        }

        //public void Save()
        //{
        //    branchRepository.Save();
        //}

        public void Update(Branch branch)
        {
            branchRepository.Update(branch);
        }
    }
}
