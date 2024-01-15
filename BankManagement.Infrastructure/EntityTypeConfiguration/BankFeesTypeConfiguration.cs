using BankManagement.Infrastructure.Models.BankCustomer.Fees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.EntityTypeConfiguration
{
    public class BankFeesTypeConfiguration : IEntityTypeConfiguration<BankFees>
    {
        public void Configure(EntityTypeBuilder<BankFees> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.SavingsFees);

            builder.Property(e => e.SavingsCommission);

            builder.Property(e => e.DepositFees);

            builder.Property(e => e.DepositCommission);

            builder.Property(e => e.CurrentFees);

            builder.Property(e => e.CurrentCommissiion);

            builder.Property(e => e.CheckingFees);

            builder.Property(e => e.CheckingCommissiion);

            builder.Property(e => e.BankCharges);
        }
    }
}
