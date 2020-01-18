using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitchenSink.Core.Customers;
using KitchenSinkApi.PersistenceEmulator.Aggregators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KitchenSinkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentCustomerController : ControllerBase
    {
        private IAggregator<Customer> _aggregator;
        public AgentCustomerController(CustomerAggregator<Customer> aggregator)
        {
            _aggregator = aggregator;
        }
        [HttpGet]
        public List<Customer> Get(int agentId)
        {
            //Normally the provider would have a querying ability. Need to emulate it here.
            var results = _aggregator.GetAll();            
            return results.Where(c => c.Agent._id == agentId).ToList();
        }
    }
}