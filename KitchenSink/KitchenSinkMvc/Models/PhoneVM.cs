using KitchenSink.Core.ContactInfo;

namespace KitchenSinkMvc.Models
{
	public class PhoneVM : Phone
	{
		public string TypeDisplay => Type.ToString().Substring(0,2);
	}
}