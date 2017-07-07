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
        public void Delete() { }
        public BaseEntity() { }
    }
    public class BaseEntity<T> : BaseEntity where T : BaseEntity, new()
    {
        private T _entity;
        private static IList<T> _db = new List<T>();
        public void Save()
        {
            if (Id == null)
            {
                _entity = new T();
                var tp = typeof(T);
                
                //.tp.GetProperties()
                _entity.Id = Guid.NewGuid().ToString();
                Id = _entity.Id;
                _db.Add(_entity);
            }
        }

        public static T Find(string id) { return _db.FirstOrDefault(x => x.Id == id); }
    }
}
