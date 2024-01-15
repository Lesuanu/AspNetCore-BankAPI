using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankManagement.Auth.ApiKey
{
    public class ApiKeyEntityTypeConfiguration : IEntityTypeConfiguration<ApiKeyModel>
    {
        public void Configure(EntityTypeBuilder<ApiKeyModel> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.UserID);

            builder.Property(x => x.Value);

            //TODO  - user
        }
    }
}
