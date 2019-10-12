using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;
namespace Data
{
    public class BankDbContext: DbContext
    {
        public BankDbContext(): base("name=BankCS")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BankDbContext, Migrations.Configuration>());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeBranch> EmployeeBranches { get; set; }

    }
}
