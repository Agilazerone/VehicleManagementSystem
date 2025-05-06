using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VM.Domain.Entities;

namespace VM.Presistence.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasData(
                new Roles { Id = 1, Name = "Super Admin", DateCreated = new DateTime(2025, 03, 20), DateModified = new DateTime(2025, 03, 20), Status = Domain.Enums.Status.Active },
                new Roles { Id = 2, Name = "Admin", DateCreated = new DateTime(2025, 03, 20), DateModified = new DateTime(2025, 03, 20), Status = Domain.Enums.Status.Active },
                new Roles { Id = 3, Name = "Engineering Director", DateCreated = new DateTime(2025, 03, 20), DateModified = new DateTime(2025, 03, 20), Status = Domain.Enums.Status.Active }
                );
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        }
    }
}
