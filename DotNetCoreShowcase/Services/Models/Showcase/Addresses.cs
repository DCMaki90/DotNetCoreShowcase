using System;
using System.Collections.Generic;

namespace DotNetCoreShowcase.Models.Showcase
{
    public partial class Addresses
    {
        public Addresses()
        {
            Users = new HashSet<Users>();
        }

        public Guid AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long Zip { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
