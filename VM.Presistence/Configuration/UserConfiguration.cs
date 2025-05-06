using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VM.Domain.Entities;

namespace VM.Presistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(120);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(120);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(120);

            builder.HasOne(x => x.Address)
                .WithOne(xr => xr.User)
                .HasForeignKey<User>(x => x.AddressId);

            builder.HasMany(e => e.UserRoles)
                .WithOne(er => er.User)
                .HasForeignKey(er => er.UserId);
        }
    }
}
