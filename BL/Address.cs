using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Address: BaseEntity<Address>
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string PostStamp { get; set; }
        public Address() : base() { }

        public Address(string fullName, string name, string postStamp, string zipCode)
        {
            FullName = fullName;
            Name = name;
            PostStamp = postStamp;
            ZipCode = zipCode;
        }

    }
}
