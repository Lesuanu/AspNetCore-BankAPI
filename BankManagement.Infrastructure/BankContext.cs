using BankManagement.Infrastructure.EntityTypeConfiguration;
using BankManagement.Infrastructure.Models.BankCustomer;
using BankManagement.Infrastructure.Models.BankCustomer.Fees;
using BankManagement.Infrastructure.Models.BankEmployee;
using BankManagement.Infrastructure.Models.Logs;
using BankManagement.Infrastructure.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BankManagement.Infrastructure
{
    public class BankContext : IdentityUserContext<IdentityUser>
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }

        public DbSet<BankEmployee1> BankEmployees { get; set; }
        public DbSet<BankEmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<BankFees> BankFees { get; set; }
        public DbSet<BankLoan> BankLoan { get; set; }
        public DbSet<BankCustomer1> BankCustomers { get; set; } 
        public DbSet<BankAddress> Addresses { get; set; }
        public DbSet<BankCustomerNextOfKin> NextOfKins { get; set; }
        public DbSet<BankLogs> BankLogs { get; set; }
        //public DbSet<ApiKeyModel> Keys { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BankEmployee1TypeConfiguration());
            modelBuilder.ApplyConfiguration(new BankEmployeeSalaryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BankFeesTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BankLogsTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BankCustomer1TypeConfiguration());
            modelBuilder.ApplyConfiguration(new BankAddressTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BankCustomerNextOfkinTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BankLoanTypeConfiguration());

            //modelBuilder.Entity<BankCustomer1>().HasData(
            //   new BankCustomer1
            //   {
            //       Id = 1,
            //       BankNumber = 2727627,
            //       FirstName = "Terry",
            //       LastName = "Crews",
            //       Email = "terrycrews@gmail.com",
            //       PhoneNumber = 2346758,
            //       Username = "terc",
            //       Profession = "Actor",
            //       BankCustomerNextOfKinId = 1,
            //       Gender = Gender.Male,
            //       Credit = 90_000_000,
            //       Debit = 22_500,
            //       BankAddressId = 1,
            //       DateRegistered = DateTime.Now
            //   }
            // );

            //modelBuilder.Entity<BankCustomerNextOfKin>().HasData(
            //    new BankCustomerNextOfKin
            //    {
            //        Id = 1,
            //        Gender = Gender.Male,
            //        BankLoanId = 1,
            //    }
            //    );

            //modelBuilder.Entity<BankLoan>().HasData(
            //    new BankLoan
            //    {
            //        Id = 1,
            //        Name = "Early Loan",
            //        IsAccountViable = true,
            //        BankAccount = 29_000_000,
            //        AmountRequested = 50_000_000,
            //        BankCustomerNextOfKinId = 1,
            //        RepaymentDate = DateTime.Now,
            //        AccountType = AccountType.Savings,
            //        InterestOnLoan = 50,
            //        BankDeposit = 87_000,
            //        EmployeeName = "terry crews",
            //        LoanDate = DateTime.Now,
            //    }
            //    );        
          }
    }
}
