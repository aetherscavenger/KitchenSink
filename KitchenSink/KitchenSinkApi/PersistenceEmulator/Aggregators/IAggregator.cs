using KitchenSink.Core.DataAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenSinkApi.PersistenceEmulator.Aggregators
{
    public interface IAggregator<T>
    {
        List<T> GetAll();
        List<T> Get(int id);
        IEntity Set(T setMe);
    }
}
