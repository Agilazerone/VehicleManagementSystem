using VM.Domain.Enums;

namespace VM.Domain.Common
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public Status Status { get; set; }
    }
}
