using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Person : BaseEntity<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public Person() : base() { }
        public Person(string firstName, string lastName, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
        protected override void HandleCloned(AbstractCloneable clone)
        {
            base.HandleCloned(clone);
            Person obj = (Person)clone;
            obj.Address = (Address)this.Address.Clone();
        }
    }
}
