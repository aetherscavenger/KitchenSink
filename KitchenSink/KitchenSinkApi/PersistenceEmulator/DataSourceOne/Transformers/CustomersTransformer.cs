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
		private IGeoCoder _geoCoder;
		public CustomersTransformer(IGeoCoder geoCoder)
		{
			_geoCoder = geoCoder;
		}
		#region Public Methods

		public TDest Transform(TOrigin from)
		{
			var returnMe = new Customer();
			returnMe._id = from._id;
			//Keep this slip, let the view model grab the details
			returnMe.Agent = new Agent { _id = from.Agent_Id };
			returnMe.Balance = float.Parse(from.Balance, NumberStyles.AllowCurrencySymbol | NumberStyles.Currency);
			returnMe.Characteristics = new List<KvP<string, string>>();
			returnMe.Characteristics.Add("Age", from.Age.ToString());
			returnMe.Characteristics.Add("EyeColor", from.EyeColor);

			returnMe.Address = new List<KvP<AddressType, Address>>();
			returnMe.Address.Add(AddressType.Primary, (Address)_geoCoder.GeoCode(from.Address));
			returnMe.Emails = new List<Email>();
			returnMe.Emails.Add(new Email { Value = from.Email, Type = ContactType.Primary });
			returnMe.Guid = from.Guid;
			returnMe.IsActive = from.IsActive;
			returnMe.FirstName = from.Name.First;
			returnMe.LastName = from.Name.Last;
			returnMe.Phones = new List<Phone>();
			returnMe.Phones.Add(new Phone { Number = from.Phone });
			returnMe.LastMobileLocation = new GeoSpatial { Latitude = float.Parse(from.Latitude), Longitude = float.Parse(from.Longitude) };
			returnMe.Tags = from.Tags.ToList();

			return (TDest)returnMe;
		}

		public TOrigin Transform(TDest from)
		{
			var returnMe = new Customers();
			returnMe._id = from._id;
			returnMe.Address = ConcatenateAddress(from.Address.FirstOrDefault(a=>a.Key == AddressType.Primary).Value);
			returnMe.Age = int.Parse(from.Characteristics.FirstOrDefault(a => a.Key == "Age").Value);
			returnMe.Agent_Id = from.Agent._id;
			returnMe.Balance = from.Balance.ToString("C2");
			returnMe.Email = from.Emails.FirstOrDefault(e => e.Type == ContactType.Primary).Value;
			returnMe.EyeColor = from.Characteristics.FirstOrDefault(a => a.Key == "EyeColor").Value;
			returnMe.Guid = from.Guid;
			returnMe.IsActive = from.IsActive;
			returnMe.Latitude = from.LastMobileLocation.Latitude.ToString();
			returnMe.Longitude = from.LastMobileLocation.Longitude.ToString();
			returnMe.Name = new NameDTO();
			returnMe.Name.First = from.FirstName;
			returnMe.Name.Last = from.LastName;
			returnMe.Phone = from.Phones.FirstOrDefault(p => p.Type == ContactType.Primary).Number;
			returnMe.Tags = from.Tags.ToArray();

			return (TOrigin)returnMe;
		}

		#endregion Public Methods

		private string ConcatenateAddress(Address address)
		{
			if (address == null)
				return string.Empty;
			return $"{address.AddressLine1}, {address.City}, {address.StateProvince}, {address.PostalCode}";
		}
	}
}