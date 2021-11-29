using System;
using System.Collections.Generic;

namespace DotNetCoreShowcase.Models.Showcase
{
    public partial class Users
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long CreationEpoch { get; set; }
        public string Email { get; set; }
        public Guid? AddressId { get; set; }

        public virtual Addresses Address { get; set; }
    }
}
