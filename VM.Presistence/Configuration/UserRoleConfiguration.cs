using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VM.Domain.Entities;

namespace VM.Presistence.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.User)
                .WithMany(u => u.UserRoles).HasForeignKey(u => u.UserId);

            builder.HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId);

        }
    }
}
