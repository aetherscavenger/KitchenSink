using KitchenSink.Core.Customers;
using KitchenSink.Core.DataAccessor;
using KitchenSink.Core.Geo;
using KitchenSinkApi.PersistenceEmulator.DataSourceOne;
using KitchenSinkApi.PersistenceEmulator.DataSourceOne.Transformers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenSinkApi.PersistenceEmulator.Aggregators
{
    public class CustomerAggregator<T> : IAggregator<T> where T : Customer
    {
        private IDataAccessor _dataAccessor;
        private IGeoCoder _geoCoder;

        public CustomerAggregator(IDataAccessor dataAccessor, IGeoCoder geoCoder)
        {
            _dataAccessor = dataAccessor;
            _geoCoder = geoCoder;
        }

        public List<T> Get(int id)
        {
            //Normally the provider or data layer filters this out, we will have to emulate it here.
            return GetAll().Where(r => r._id == id).ToList();
        }

        public List<T> GetAll()
        {
            //Better to use reflection here. Refactor if there's time
            var dataSourceOne = _dataAccessor.Read<Customers>();
            var transformer = new CustomersTransformer<Customers, Customer>(_geoCoder);
            var returnUs = new List<T>();
            foreach (var agent in dataSourceOne)
            {
                returnUs.Add((T)transformer.Transform(agent));
            }
            return returnUs;
        }

        public void Remove(int id)
        {
            _dataAccessor.Delete<Customers>(id);
        }

        public IEntity Set(T setMe)
        {
            var transformer = new CustomersTransformer<Customers, Customer>(_geoCoder);
            var saveMe = transformer.Transform(setMe);
            var result = _dataAccessor.Write<Customers>(saveMe, null);
            return transformer.Transform(result.Payload);
        }
    }
}
