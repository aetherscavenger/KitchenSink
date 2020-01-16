using KitchenSink.Core.DataAccessor;
using System;

namespace KitchenSinkApi.PersistenceEmulator.DataSourceTwo
{
    public class Clients : IEntity
    {
        public int _id { get; set; }

        public void Replace(IEntity replaceWithMe)
        {
            throw new NotImplementedException();
        }
    }
}