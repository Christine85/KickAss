using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.Models
{
    public class Address
    {
        public Address(int addressId, string street, string zip, string city)
        {
            AddressId = addressId;
            Street = street;
            Zip = zip;
            City = city;
        }
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
    }
}
