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
    public class BankAddressTypeConfiguration : IEntityTypeConfiguration<BankAddress>
    {
        public void Configure(EntityTypeBuilder<BankAddress> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PhoneNumber);

            builder.Property(x => x.Email);

            builder.Property(x => x.City);

            builder.Property(x => x.State);

            builder.Property(x => x.Region);

         //   builder.HasOne(x => x.BankCustomerNextOfKin)
           //     .WithOne(x => x.BankAddress)
             //   .HasForeignKey<BankCustomerNextOfKin>(x => x.BankAddressId);

            builder.HasOne(x => x.BankCustomer1)
              .WithOne(x => x.BankAddress)
                .HasForeignKey<BankCustomer1>(x => x.BankAddressId);    
        }
    }
}
