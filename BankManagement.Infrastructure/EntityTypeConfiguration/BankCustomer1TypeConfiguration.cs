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
    public class BankCustomer1TypeConfiguration : IEntityTypeConfiguration<BankCustomer1>
    {
        public void Configure(EntityTypeBuilder<BankCustomer1> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.BankNumber)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .IsRequired();

            builder.Property(x => x.LastName)
                .IsRequired();

            builder.Property<string>(x => x.Email)
                .HasMaxLength(50);

            builder.Property(x => x.PhoneNumber)
                .IsRequired();

            builder.Property(x => x.Username);

            builder.Property(x => x.DateRegistered);

            builder.Property(x => x.Credit);

            builder.Property(x => x.Debit);

            builder.Property(x => x.Profession);

            builder.Property(x => x.Gender)
             .HasConversion(x => x.ToString(),
              v => (Gender)Enum.Parse(typeof(Gender), v));

            builder.HasOne<BankCustomerNextOfKin>(x => x.BankCustomerNextOfKin)
                .WithOne(x => x.BankCustomer1)
                .HasForeignKey<BankCustomer1>(x => x.BankCustomerNextOfKinId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<BankAddress>(x => x.BankAddress)
                .WithOne(x => x.BankCustomer1)
                .HasForeignKey<BankCustomer1>(x => x.BankAddressId);
        }
    }
}
