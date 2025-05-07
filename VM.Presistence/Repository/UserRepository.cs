using Microsoft.EntityFrameworkCore;
using VM.Domain.Contracts.Presistence;
using VM.Domain.Entities;
using VM.Domain.Enums;
using VM.Presistence.DatabaseContext;

namespace VM.Presistence.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly VehicleMangementDbContext _context;
        public UserRepository(VehicleMangementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            // Use Entity Framework to query the database and retrieve the employee by email
            return await _context.Users
                                 .FirstOrDefaultAsync(e => e.Email == email && e.Status == Status.Active);
        }
    }
}
