using KitchenSink.Core.Agents;
using KitchenSink.Core.DataAccessor;
using KitchenSink.Core.Geo;
using System;
using System.Collections.Generic;

namespace KitchenSinkMvc.Models
{
	public class Agent : IEntity
	{
		public Address Address { get; set; }
		public List<PhoneVM> Phones { get; set; }
		public int Tier { get; set; }
		public int _id { get; set; }
		public string DisplayName { get; set; }

		public void Replace(IEntity replaceWithMe)
		{
			throw new NotImplementedException();
		}
	}
}