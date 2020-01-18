using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitchenSink.Core.Customers;
using KitchenSink.Core.DataAccessor;
using KitchenSinkApi.PersistenceEmulator.Aggregators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KitchenSinkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IAggregator<Customer> _aggregator;
        public CustomerController(CustomerAggregator<Customer> aggregator)
        {
            _aggregator = aggregator;
        }
        [HttpGet]
        public List<Customer> Get(int? id = null)
        {
            if (id != null)
            {
                return _aggregator.Get((int)id);
            }

            var results = _aggregator.GetAll();
            return results;
        }
        [HttpPost]
        public IEntity Post([FromBody] Customer customer)
        {

            //TODO 20200118-00003 create model sanitizer
            if (customer._id == default(int))
                customer.Guid = Guid.NewGuid();

            if(customer.Tags == null)
                customer.Tags = new List<string>();
            
            var result = _aggregator.Set(customer);
            return result;
        }

        [HttpDelete]
        public bool Delete(int id)
        {

            _aggregator.Remove(id);
            return true;
        }
    }
}