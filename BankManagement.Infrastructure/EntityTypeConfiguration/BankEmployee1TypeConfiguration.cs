using BankManagement.Infrastructure.Models.BankEmployee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BankManagement.Infrastructure.EntityTypeConfiguration
{
    public class BankEmployee1TypeConfiguration : IEntityTypeConfiguration<BankEmployee1>
    {
        public void Configure(EntityTypeBuilder<BankEmployee1> builder)
        {
            builder.HasKey(x => x.BankEmployee1Id);

            builder.Property(x => x.FirstName)
                .IsRequired();

            builder.Property(x => x.LastName)
                .IsRequired();

            builder.HasOne<BankEmployeeSalary>(x => x.BankEmployeeSalary)
                .WithOne(x => x.BankEmployee1)
                .HasForeignKey<BankEmployeeSalary>(x => x.BankEmployee1Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property<DateTime>(x => x.DatePromoted)
                .IsRequired();

            builder.Property<DateTime>(x => x.DateEmployed)
                .IsRequired();

            builder.Property(x => x.EmployeeDepartment)
               .HasConversion(x => x.ToString(),
                v => (EmployeeDepartment)Enum.Parse(typeof(EmployeeDepartment), v));     

        }
    }
}
