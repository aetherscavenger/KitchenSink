using KitchenSink.Core.People;

namespace KitchenSink.Core.ContactInfo
{
    public interface IEmail : IPII
    {
        string Email { get; set; }
        ContactType Type { get; set; }
    }
}