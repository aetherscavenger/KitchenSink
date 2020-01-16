using KitchenSink.Core.ContactInfo;
using KitchenSink.Core.DataAccessor;
using KitchenSink.Core.Geo;
using KitchenSink.Core.People;
using System.Collections.Generic;

namespace KitchenSink.Core.Agents
{
    /*
     *
     * Volatility high. 1st data source has rudimentary storage of details.
     * It is unlikely other data sources will store in this manner.
     *
     */

    public interface IAgent : IEntity, IQuickContact
    {
        Address Address { get; set; }
        List<Phone> Phones { get; set; }
        int Tier { get; set; }
    }
}