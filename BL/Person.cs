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

        public override bool Equals(object obj)
        {
            var item = obj as Person;
            if (item == null)
                return false;

            var tpObj = obj.GetType();
            var tp = this.GetType();
            if (tpObj != tp)
                return false;

            if (String.IsNullOrWhiteSpace(Id) || String.IsNullOrWhiteSpace(item.Id))
                return this.GetHashCode(true) == item.GetHashCode(true);
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            if (base.GetHashCode() != 0)
                return base.GetHashCode();
            else
                return GetHashCode(true);
        }
        public int GetHashCode(bool dontCheckId)
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode() ^ Address.GetHashCode();
        }
    }
}
