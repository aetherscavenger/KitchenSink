using KitchenSink.Core;
using KitchenSink.Core.Auth;
using KitchenSink.Core.ContactInfo;
using KitchenSink.Core.Customers;
using KitchenSink.Core.DataAccessor;
using KitchenSink.Core.Geo;
using KitchenSink.Core.People;
using System;
using System.Collections.Generic;

namespace KitchenSinkMvc.Models
{
	public class AgentCustomer : ICustomer
	{
		#region Public Properties

		public int _id { get; set; }
		public List<KvP<AddressType, Address>> Address { get; set; }
		public KitchenSink.Core.Agents.Agent Agent { get; set; }
		public float Balance { get; set; }
		public DateTime? BirthDate { get; set; }
		public List<KvP<string, string>> Characteristics { get; set; }
		public List<Email> Emails { get; set; }
		public string EncryptedPayload { get; set; }
		public string FirstName { get; set; }
		public Guid Guid { get; set; }
		public bool IsActive { get; set; }
		public GeoSpatial LastMobileLocation { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public List<Phone> Phones { get; set; }
		public string PreferredName { get; set; }
		public List<string> Tags { get; set; }

		#endregion Public Properties

		#region Public Methods

		public IPII Decrypt(ICrypto crypto)
		{
			throw new NotImplementedException();
		}

		public IPII Encrypt(ICrypto crypto)
		{
			throw new NotImplementedException();
		}

		public IPII Obfuscate(IDictionary<string, string> parameters)
		{
			throw new NotImplementedException();
		}

		public void Replace(IEntity replaceWithMe)
		{
			throw new NotImplementedException();
		}

		#endregion Public Methods
	}
}