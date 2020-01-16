using KitchenSink.Core.Agents;
using KitchenSink.Core.Auth;
using KitchenSink.Core.ContactInfo;
using KitchenSink.Core.DataAccessor;
using KitchenSink.Core.Geo;
using KitchenSink.Core.People;
using System;
using System.Collections.Generic;

namespace KitchenSink.Core.Customers
{
	public class Customer : ICustomer
	{
		#region Private Fields

		private const string OBFUSCATE = "****";

		#endregion Private Fields

		#region Public Properties

		public int _id { get; set; }
		public List<KvP<AddressType, Address>> Address { get; set; }
		public Agent Agent { get; set; }
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
			return (IPII)crypto.Decrypt(EncryptedPayload);
		}

		public IPII Encrypt(ICrypto crypto)
		{
			EncryptedPayload = crypto.Encrypt(this);
			return this;
		}

		public IPII Obfuscate(IDictionary<string, string> parameters)
		{
			//TODO: 20200116-00002: Switch from string, string to string, object and
			//create SafeCast
			foreach (var param in parameters)
			{
				var prop = GetType().GetProperty(param.Key);
				if (prop.PropertyType == typeof(string))
					prop.SetValue(this, param.Value);
			}
			FirstName = OBFUSCATE;
			MiddleName = OBFUSCATE;
			LastName = OBFUSCATE;
			return this;
		}

		public void Replace(IEntity replaceWithMe)
		{
			throw new NotImplementedException();
		}

		#endregion Public Methods
	}
}