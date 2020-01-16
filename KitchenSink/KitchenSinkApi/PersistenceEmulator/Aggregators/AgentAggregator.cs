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

        public List<T> Get(int id)
        {
            //Normally the provider or data layer filters this out, we will have to emulate it here.
            return GetAll().Where(r => r._id == id).ToList();
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

        public IEntity Set(T setMe)
        {
            var transformer = new AgentsTransformer<Agents, Agent>();
            var saveMe = transformer.Transform(setMe);
            var result = _dataAccessor.Write<Agents>(saveMe, null);
            return result.Payload;
        }
    }
}
