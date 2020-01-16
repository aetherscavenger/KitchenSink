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
            var results = _aggregator.GetAll();

            if (id != null)
            {
                return _aggregator.Get((int)id);
            }

            return results;
        }
        [HttpPost]
        public IEntity Post([FromBody] Customer customer)
        {
            var result = _aggregator.Set(customer);
            return result;
        }
    }
}