using VM.Domain.Common;
using VM.Domain.Enums;

namespace VM.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }
        public Gender Gender { get; set; }
        public long AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
