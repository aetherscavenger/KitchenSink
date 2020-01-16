using KitchenSink.Core.Agents;
using KitchenSink.Core.ContactInfo;
using KitchenSink.Core.DataAccessor;
using KitchenSink.Core.Geo;
using KitchenSink.Core.People;
using System;
using System.Collections.Generic;

namespace KitchenSink.Core.Customers
{
	/*
     *
     * Volatility high for customer information. Including details like eye color implies we will
     * need extensible details.
     *
     */

	public interface ICustomer : IEntity, IPerson
	{
		#region Public Properties

		Guid Guid { get; set; }
		List<KvP<AddressType, Address>> Address { get; set; }
		Agent Agent { get; set; }

		//This should probably be represented by transactions rather than a float
		//KISS for now.
		float Balance { get; set; }

		List<Email> Emails { get; set; }
		bool IsActive { get; set; }
		List<Phone> Phones { get; set; }
		List<string> Tags { get; set; }

		#endregion Public Properties
	}
}