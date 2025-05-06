using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VM.Domain.Common;
using VM.Domain.Entities;

namespace VM.Presistence.DatabaseContext
{
    public class VehicleMangementDbContext : DbContext
    {
        public readonly IConfiguration _configuration;
        public DbSet<User> Users;
        public DbSet<Address> Address;
        public DbSet<Roles> Roles;
        public DbSet<UserRoles> UserRoles;
        public VehicleMangementDbContext(DbContextOptions<VehicleMangementDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleMangementDbContext).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(_configuration["TablePrefix"] + entityType.GetTableName());
            }
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
