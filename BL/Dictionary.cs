using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Dictionary
    {
        public Dictionary()
        {
            _data = new Dictionary<BaseEntity, BaseEntity>();
        }
        private IDictionary<BaseEntity, BaseEntity> _data;
        public BaseEntity this[BaseEntity entity]
        {
            get
            {
                if (ContainsKey(entity))
                    return _data[entity];
                else
                    throw new ArgumentException("There is no such key");
            }
            set
            {
                _data.Add(value, value);
            }
        }

        public bool ContainsKey(BaseEntity entity)
        {
            return _data.Any(x => x.Key.Equals(entity));
        }

    }
}
