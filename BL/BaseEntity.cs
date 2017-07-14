using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BL
{
    [Serializable]
    public class BaseEntity<T> where T : BaseEntity<T>, new()
    {
        public string Id { get; set; }

        public void Delete()
        {
            if (!String.IsNullOrWhiteSpace(this.Id))
            {
                var fullPath = Path.Combine(Config.FilesPath, this.Id);
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
            }
            Id = null;
        }
        public void Save()
        {
            if (!String.IsNullOrWhiteSpace(Id) && Find(Id) != null)
                return; //TODO: Get entity from _db and Update properties 
            else
            {
                //Genetare Id only if we don't have one
                if (String.IsNullOrWhiteSpace(this.Id))
                    Id = Guid.NewGuid().ToString();
                var savePath = Path.Combine(Config.FilesPath, Id);
                SerializeDeserializeHelper.SerializeObject(this, savePath);
            }
        }

        public static T Find(string id)
        {
            if (id == null)
                return null;
            var fullPath = Path.Combine(Config.FilesPath, id);
            if (File.Exists(fullPath))
                return SerializeDeserializeHelper.DeSerializeObject<T>(fullPath);
            else
                return null;
        }

        protected bool EqualsByProperties(object obj)
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

        public override bool Equals(object obj)
        {
            var item = obj as T;
            if (item == null)
                return false;

            var tpObj = obj.GetType();
            var tp = this.GetType();
            if (tpObj != tp)
                return false;

            if (!String.IsNullOrWhiteSpace(Id) && !String.IsNullOrWhiteSpace(item.Id))
                return this.GetHashCode() == item.GetHashCode();
            else
                return EqualsByProperties(obj);
        }

        public override int GetHashCode()
        {
            if (String.IsNullOrWhiteSpace(Id))
                Id = Guid.NewGuid().ToString();
            return Id.GetHashCode();
        }
    }
}
