using VM.Domain.Common;

namespace VM.Domain.Entities
{
    public class UserRoles : BaseEntity
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public User User { get; set; }
        public Roles Role { get; set; }
    }
}
