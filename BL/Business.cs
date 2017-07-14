using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Business : BaseEntity<Business>
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Business() : base() { }
        public Business(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Business;
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
            return Address.GetHashCode() ^ Name.GetHashCode();
        }
    }
}
