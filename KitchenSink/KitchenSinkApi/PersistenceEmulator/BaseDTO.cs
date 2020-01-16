using KitchenSink.Core.DataAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenSinkApi.PersistenceEmulator
{
    public abstract class BaseDTO : IEntity
    {
        public int _id { get; set; }

        public virtual void Replace(IEntity replaceWithMe)
        {
            Replace(replaceWithMe);
        }
    }
}
