using BankManagement.Infrastructure.Models.BankCustomer;
using BankManagement.Infrastructure.Models.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.EntityTypeConfiguration
{
    public class BankLoanTypeConfiguration : IEntityTypeConfiguration<BankLoan>
    {
        public void Configure(EntityTypeBuilder<BankLoan> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name);

            builder.Property(x => x.IsAccountViable);

            builder.Property(x => x.BankAccount);

            builder.Property(x => x.AmountRequested);

            builder.Property(x => x.RepaymentDate);

            builder.Property(x => x.InterestOnLoan);

            builder.Property(x => x.BankDeposit);

            builder.Property(x => x.EmployeeName);

            builder.Property(x => x.LoanDate);

            builder.HasOne(x => x.BankCustomerNextOfKin)
                .WithOne(x => x.BankLoan)
                .HasForeignKey<BankLoan>(x => x.BankCustomerNextOfKinId);

            builder.Property(x => x.AccountType)
                .HasConversion(x => x.ToString(),
                 v => (AccountType)Enum.Parse(typeof(AccountType), v));
        }
    }
}
