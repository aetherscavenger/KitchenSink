using KitchenSink.Core.ContactInfo;
using KitchenSink.Core.DataAccessor;
using KitchenSink.Core.Geo;
using System;
using System.Collections.Generic;

namespace KitchenSink.Core.Agents
{
    public class Agent : IAgent
    {
        public int _id { get; set; }
        public IAddress Address { get; set; }
        public string DisplayName { get; set; }
        public IList<IPhone> Phones { get; set; }
        public int Tier { get; set; }

        public void Replace(IEntity replaceWithMe)
        {
            //Do nothing for now. Evaluate transformer process first
            return;
        }
    }
}