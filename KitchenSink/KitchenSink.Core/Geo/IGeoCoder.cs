using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.Geo
{
	public interface IGeoCoder
	{
		IAddress GeoCode(string address);
	}
}
