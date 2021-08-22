using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextTry.Class
{
    public sealed class ContractDbContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=contractsDB;Username=postgres;Password=393318156a");
        }
    /*,
  "ConnectionStrings": {
    "DefaultConnection": "Server:localhost:5432;Initial Catalog=contractsDB;MultipleActiveResultSets=true;User ID=postgres;Password=393318156a"
    */
        //public ContractDbContext(DbContextOptions<ContractDbContext> options)
        //    : base(options)
        //{
        //    Database.EnsureCreated();
        //}
    }
}
