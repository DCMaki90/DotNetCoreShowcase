using System;

namespace DotNetCoreShowcase.SampleDB.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CreationEpoch { get; set; }
        public string Email { get; set; }
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
