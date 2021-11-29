using System;

namespace DotNetCoreShowcase.SampleDB.Models
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Country { get; set; }
    }
}
