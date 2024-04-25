
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace WebApplication5.Models
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankBranch>().HasData(
                new BankBranch
                {
                    Id = 1,
                    location = "Alshamyia",
                    branchManager = "Abdulrahman",
                    employeeCount = 7,
                    locationURL = "https://maps.app.goo.gl/k5DD4wvKX38Y6RFQ7"
                }
            );
        }

        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
