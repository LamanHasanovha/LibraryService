using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(x => x.Id);
            builder.Property(a => a.Id).ValueGeneratedNever();

            builder.Property(a => a.FirstName).HasColumnName("FirstName");
            builder.Property(a => a.LastName).HasColumnName("LastName");
            builder.Property(a => a.Email).HasColumnName("Email");
            builder.Property(a => a.Username).HasColumnName("Username");
            builder.Property(a => a.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(a => a.PasswordSalt).HasColumnName("PasswordSalt");
            builder.Property(a => a.LastLoginDate).HasColumnName("LastLoginDate");
            builder.Property(a => a.Status).HasColumnName("Status");
        }
    }
}
