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
            _data = new List<BaseEntity>();
        }
        private IList<BaseEntity> _data;
        public BaseEntity this[BaseEntity entity]
        {
            get
            {
                return _data.Single(x => x == entity);
            }
            set
            {
                _data.Add(value);
            }
        }

        public bool ContainsKey(BaseEntity entity)
        {
            return _data.Any(x => x.EqualsByProperties(entity));
        }

    }
}
