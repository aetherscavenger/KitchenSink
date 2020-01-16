using KitchenSink.Core.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenSinkApi.PersistenceEmulator.Aggregators
{
    public class CustomerAggregator<T> : IAggregator<T> where T : Customer
    {
        public List<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
