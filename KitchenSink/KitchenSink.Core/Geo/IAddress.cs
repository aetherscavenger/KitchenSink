namespace KitchenSink.Core.Geo
{
    public interface IAddress
    {
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
        string StateProvince { get; set; }
    }
}