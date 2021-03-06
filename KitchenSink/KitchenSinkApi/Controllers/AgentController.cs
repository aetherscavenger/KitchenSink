﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitchenSink.Core.Agents;
using KitchenSink.Core.DataAccessor;
using KitchenSinkApi.PersistenceEmulator.Aggregators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KitchenSinkApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private IAggregator<Agent> _aggregator;
        public AgentController(AgentAggregator<Agent> aggregator)
        {
            _aggregator = aggregator;
        }
        public List<Agent> Get(int? id = null)
        {
            if(id != null)
            {
                return _aggregator.Get((int)id);
            }
            var results = _aggregator.GetAll();
            return results;
        }
        [HttpPost]
        public IEntity Post([FromBody]Agent agent)
        {
            var result = _aggregator.Set(agent);
            return result;
        }
    }
}