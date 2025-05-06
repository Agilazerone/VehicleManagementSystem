using VM.Domain.Common;

namespace VM.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public User User { get; set; }
    }
}
