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
    public class BankLogsTypeConfiguration : IEntityTypeConfiguration<BankLogs>
    {
        public void Configure(EntityTypeBuilder<BankLogs> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OwnerName);

            builder.Property(x => x.AmountWithdrawn)
                .IsRequired();

            builder.Property(x => x.DateWithdrawn);

            builder.Property(x => x.AmountDeposited);

            builder.Property(x => x.DateDeposited);
        }

        public static int GetAmount(int amount)
        {
            return amount > 0 ? amount : 0;
        }
    }
}
