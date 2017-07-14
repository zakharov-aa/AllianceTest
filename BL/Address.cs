using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Address : BaseEntity<Address>
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

        public override bool Equals(object obj)
        {
            var item = obj as Address;
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
            return FullName.GetHashCode() ^ Name.GetHashCode() ^ ZipCode.GetHashCode() ^ PostStamp.GetHashCode();
        }
    }
}
