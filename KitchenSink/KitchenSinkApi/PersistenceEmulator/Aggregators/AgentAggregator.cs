using KitchenSink.Core.Agents;
using KitchenSink.Core.DataAccessor;
using KitchenSinkApi.PersistenceEmulator.DataSourceOne;
using KitchenSinkApi.PersistenceEmulator.DataSourceOne.Transformers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenSinkApi.PersistenceEmulator.Aggregators
{
    public class AgentAggregator<T> : IAggregator<T> where T : Agent
    {
        private IDataAccessor _dataAccessor;

        public AgentAggregator(IDataAccessor dataAccessor)
        {
            _dataAccessor = dataAccessor;
        }
        public List<T> GetAll()
        {
            //Better to use reflection here. Refactor if there's time
            var dataSourceOne = _dataAccessor.Read<Agents>();
            var transformer = new AgentsTransformer<Agents, Agent>();
            var returnUs = new List<T>();
            foreach (var agent in dataSourceOne)
            {
                returnUs.Add((T)transformer.Transform(agent));
            }
            return returnUs;
        }
    }
}
