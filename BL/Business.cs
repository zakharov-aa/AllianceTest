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
        protected override void HandleCloned(AbstractCloneable clone)
        {
            base.HandleCloned(clone);
            Business obj = (Business)clone;
            obj.Address = (Address)this.Address.Clone();
        }
    }
}
