using BankManagement.Infrastructure.Models.BankCustomer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.SeedData
{
    public static class SeedExtensions
    {
        public static void Seeder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankCustomer1>().HasData(
                new BankCustomer1
                {
                    Id = 1,
                    BankNumber = 2727627,
                    FirstName = "Terry",
                    LastName = "Crews",
                    Email = "terrycrews@gmail.com",
                    PhoneNumber = 2346758,
                    Username = "terc",
                    Profession = "Actor",
                    BankCustomerNextOfKinId = 1,
                    Gender = Gender.Male,
                    Credit = 90_000_000,
                    Debit = 22_500,
                    BankAddressId = 1,
                    DateRegistered = DateTime.Now
                }
           );

            modelBuilder.Entity<BankCustomerNextOfKin>().HasData(
                new BankCustomerNextOfKin
                {
                    Id = 1,
                    Gender = Gender.Male,
                    BankLoanId = 1,
                }
                );

            modelBuilder.Entity<BankLoan>().HasData(
                new BankLoan
                {
                    Id = 1,
                    Name = "Early Loan",
                    IsAccountViable = true,
                    BankAccount = 29_000_000,
                    AmountRequested = 50_000_000,
                    BankCustomerNextOfKinId = 1,
                    RepaymentDate = DateTime.Now,
                    AccountType = AccountType.Savings,
                    InterestOnLoan = 50,
                    BankDeposit = 87_000,
                    EmployeeName = "terry crews",
                    LoanDate = DateTime.Now,
                }
                );
        }
    }
}
