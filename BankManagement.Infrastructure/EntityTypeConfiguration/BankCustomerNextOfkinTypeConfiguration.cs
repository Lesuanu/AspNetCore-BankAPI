using BankManagement.Infrastructure.Models.BankCustomer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.EntityTypeConfiguration
{
    internal class BankCustomerNextOfkinTypeConfiguration : IEntityTypeConfiguration<BankCustomerNextOfKin>
    {
        public void Configure(EntityTypeBuilder<BankCustomerNextOfKin> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Gender)
                .HasConversion(x => x.ToString(),
                v => (Gender)Enum.Parse(typeof(Gender), v));

           // builder.HasOne<BankAddress>(x => x.BankAddress)
             //   .WithOne(x => x.BankCustomerNextOfKin)
               // .HasForeignKey<BankCustomerNextOfKin>(x => x.BankAddressId);

            builder.HasOne<BankCustomer1>(x => x.BankCustomer1)
                .WithOne(x => x.BankCustomerNextOfKin)
                .HasForeignKey<BankCustomer1>(x => x.BankCustomerNextOfKinId);

            builder.HasOne<BankLoan>(x => x.BankLoan)
                .WithOne(x => x.BankCustomerNextOfKin)
                .HasForeignKey<BankCustomerNextOfKin>(x => x.BankLoanId);
        }
    }
}
