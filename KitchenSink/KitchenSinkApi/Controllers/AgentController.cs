using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitchenSink.Core.Agents;
using KitchenSink.Core.DataAccessor;
using KitchenSinkApi.PersistenceEmulator.Aggregators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KitchenSinkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private IAggregator<Agent> _aggregator;
        public AgentController(AgentAggregator<Agent> dataAccessor)
        {
            _aggregator = dataAccessor;
        }
        public List<Agent> Get(int? id = null)
        {
            _aggregator.Read<Agents>
        }
    }
}