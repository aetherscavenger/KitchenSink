using KitchenSink.Core;
using KitchenSink.Core.Agents;
using KitchenSink.Core.ContactInfo;
using KitchenSink.Core.Customers;
using KitchenSink.Core.DataAccessor;
using KitchenSink.Core.Extensions;
using KitchenSink.Core.Geo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace KitchenSinkApi.PersistenceEmulator.DataSourceOne.Transformers
{
	public class CustomersTransformer<TOrigin, TDest> : ITransformer<TOrigin, TDest>
		where TOrigin : Customers
		where TDest : Customer
	{
		#region Public Methods

		public TDest Transform(TOrigin from)
		{
			var returnMe = new Customer();
			returnMe._id = from._id;
			//Keep this slip, let the view model grab the details
			returnMe.Agent = new Agent { _id = from.AgentId };
			returnMe.Balance = float.Parse(from.Balance, NumberStyles.AllowCurrencySymbol | NumberStyles.Currency);
			returnMe.Characteristics = new List<KvP<string, string>>();
			returnMe.Characteristics.Add("Age", from.Age.ToString());
			returnMe.Characteristics.Add("EyeColor", from.EyeColor);

			returnMe.Address = new List<KvP<AddressType, IAddress>>();
			returnMe.Address.Add(AddressType.Primary, new Address { AddressLine1 = from.Address });
			returnMe.Emails = new List<IEmail>();
			returnMe.Emails.Add(new Email { Value = from.Email, Type = ContactType.Primary });
			returnMe.IsActive = from.IsActive;
			returnMe.FirstName = from.Name.First;
			returnMe.LastName = from.Name.Last;
			returnMe.Phones = new List<IPhone>();
			returnMe.Phones.Add(new Phone { Number = from.Phone });
			returnMe.LastMobileLocation = new GeoSpatial { Latitude = float.Parse(from.Latitude), Longitude = float.Parse(from.Longitude) };
			returnMe.Tags = from.Tags.ToList();

			return (TDest)returnMe;
		}

		public TOrigin Transform(TDest from)
		{
			throw new NotImplementedException();
		}

		#endregion Public Methods
	}
}