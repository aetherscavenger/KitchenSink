namespace KitchenSink.Core.ContactInfo
{
    /*
     * Tossing in SMS only because it's highly debated whether this should be included
     * early on.
     */

    public interface IPhone
    {
        bool CanSms { get; set; } //A bit of over engineering here.
        string Extension { get; set; } //A bit of over engineering here
        string Number { get; set; }
        bool OptInSms { get; set; } //A bit of over engineering here
        ContactType Type { get; set; }
    }
}