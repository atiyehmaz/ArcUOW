using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Data
{
    public interface IUnitOfWork
    {
        //TContext Context { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
        bool Successful { get; set; }


    }
}
