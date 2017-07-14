using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Business: BaseEntity<Business>
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Business() : base() { }
        public Business(string name, Address address)
        {
            Name = name;
            Address = address;
        }
        public override int GetHashCode()
        {
            if (base.GetHashCode() != 0)
                return base.GetHashCode();
            else
                return Address.GetHashCode() ^ Name.GetHashCode();
        }
    }
}
