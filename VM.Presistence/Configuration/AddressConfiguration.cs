using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VM.Domain.Entities;

namespace VM.Presistence.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Street).IsRequired().HasMaxLength(200);
            builder.Property(x => x.City).IsRequired().HasMaxLength(200);
            builder.Property(x => x.PostalCode).IsRequired().HasMaxLength(200);
            builder.Property(x => x.State).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(200);

        }
    }
}
