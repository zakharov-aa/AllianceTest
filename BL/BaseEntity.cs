using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public void Save()
        {
            if (Id == null)
                Id = Guid.NewGuid().ToString();
        }
        public void Delete() { }
        public BaseEntity() { }
    }
    public class BaseEntity<T> : BaseEntity where T : new()
    {

        public static T Find(string id) { return new T(); }
    }
}
