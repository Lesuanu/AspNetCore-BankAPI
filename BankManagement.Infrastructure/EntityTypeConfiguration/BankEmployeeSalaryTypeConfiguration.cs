using BankManagement.Infrastructure.Models.BankEmployee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BankManagement.Infrastructure.EntityTypeConfiguration
{
    public class BankEmployeeSalaryTypeConfiguration : IEntityTypeConfiguration<BankEmployeeSalary>
    {
        public void Configure(EntityTypeBuilder<BankEmployeeSalary> builder)
        {
            builder.HasKey(x => x.Id);
                

            builder.Property(x => x.MonthlySalary)
                .IsRequired();

            builder.Property(x => x.AnualSalary)
                .IsRequired();

            builder.Property(x => x.TaxPayable).IsRequired();

            builder.HasOne<BankEmployee1>(x => x.BankEmployee1)
                .WithOne(x => x.BankEmployeeSalary)
                .HasForeignKey<BankEmployeeSalary>(x => x.BankEmployee1Id)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
