using KitchenSink.Core.DataAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenSinkApi.PersistenceEmulator.DataSourceTwo
{
    public class Agency : IEntity
    {
        public int _id { get; set; }

        public void Replace(IEntity replaceWithMe)
        {
            throw new NotImplementedException();
        }
    }
}
