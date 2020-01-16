using KitchenSink.Core.DataAccessor;

namespace KitchenSinkApi.PersistenceEmulator.DataSourceOne
{
    public class Agents : BaseDTO
    {
        public string City { get; set; }
        public string Name { get; set; }
        public PhoneDTO Phone { get; set; }
        public string State { get; set; }
        public int Tier { get; set; }
        public string ZipCode { get; set; }
    }
}