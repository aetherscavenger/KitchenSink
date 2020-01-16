using KitchenSink.Core.People;

namespace KitchenSink.Core.ContactInfo
{
    public interface IEmail : IPII
    {
        ContactType Type { get; set; }
        string Value { get; set; }
    }
}