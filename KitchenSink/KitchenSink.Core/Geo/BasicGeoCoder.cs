using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.Geo
{
	public class BasicGeoCoder : IGeoCoder
	{
		public IAddress GeoCode(string address)
		{
			var split = address.Split(',');

			var returnMe = new Address();
			if(split.Length > 0)
				returnMe.AddressLine1 = split[0];
			if (split.Length > 1)
				returnMe.City = split[1];
			if (split.Length > 2)
				returnMe.StateProvince = split[2];

			if (split.Length > 3) 
				returnMe.PostalCode = split[3];

			return returnMe;
		}
	}
}
