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
        public BaseEntity this[BaseEntity index]
        {
            get
            {
                return new BaseEntity();
            }
            set
            {
            }
        }

        public bool ContainsKey(BaseEntity entity) { return true; }
    }
}
