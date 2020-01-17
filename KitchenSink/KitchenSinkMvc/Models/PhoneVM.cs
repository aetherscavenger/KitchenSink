using KitchenSink.Core.ContactInfo;

namespace KitchenSinkMvc.Models
{
	public class PhoneVM : Phone
	{
		public char TypeDisplay => Type.ToString()[0];
	}
}