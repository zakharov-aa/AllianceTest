using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public abstract class AbstractCloneable : ICloneable
    {
        public virtual object Clone()
        {
            var clone = (AbstractCloneable)this.MemberwiseClone();
            HandleCloned(clone);
            return clone;
        }

        protected virtual void HandleCloned(AbstractCloneable clone)
        {
            //Nothing particular in the base class, but maybe usefull for childs.
            //Not abstract so childs may not implement this if they don't need to.
        }
    }
}
