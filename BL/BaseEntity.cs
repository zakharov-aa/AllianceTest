using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BaseEntity : AbstractCloneable
    {
        public string Id { get; set; }
        public bool EqualsByProperties(object obj)
        {
            var tpObj = obj.GetType();
            var tp = this.GetType();
            if (tpObj != tp)
                return false;
            else
                foreach (var property in tp.GetProperties())
                {
                    if (property.Name != "Id")
                    {
                        var valueObj = property.GetValue(obj, null);
                        var value = property.GetValue(this, null);
                        if (valueObj != value)
                            return false;
                    }
                }
            return true;
        }
        protected override void HandleCloned(AbstractCloneable clone)
        {
            base.HandleCloned(clone);
            BaseEntity obj = (BaseEntity)clone;
        }
        public BaseEntity() { }
    }
    public class BaseEntity<T> : BaseEntity where T : BaseEntity, new()
    {
        private T _entity;
        private static IList<T> _db = new List<T>();
        public void Delete()
        {
            var removeEntity = _db.FirstOrDefault(x => x.Id == this.Id);
            _db.Remove(removeEntity);
            Id = String.Empty;
        }
        public void Save()
        {
            if (Id == null)
            {
                _entity = new T();
                var tp = typeof(T);
                //Set All properties
                foreach (var property in tp.GetProperties())
                {
                    if (property.PropertyType.BaseType.IsGenericType
                        && property.PropertyType.BaseType.BaseType == typeof(BaseEntity))
                    {
                        var methodInfo = property.PropertyType.BaseType.GetMethod("Save");
                        var value = property.GetValue(this, null);
                        var res = methodInfo.Invoke(value, null);
                        property.SetValue(_entity, value);
                    }
                    else
                    {
                        var value = property.GetValue(this, null);
                        property.SetValue(_entity, value);
                    }
                }
                if (String.IsNullOrWhiteSpace(_entity.Id))
                    _entity.Id = Guid.NewGuid().ToString();
                Id = _entity.Id;
                _db.Add(_entity);
            }
        }

        public override bool Equals(object obj)
        {
            var item = obj as T;
            if (item == null)
                return false;

            return this.GetHashCode() == item.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static T Find(string id)
        {
            var findRes = _db.FirstOrDefault(x => x.Id == id);
            if (findRes != null)
                return findRes.Clone() as T;
            else
                return null;
        }
    }
}
