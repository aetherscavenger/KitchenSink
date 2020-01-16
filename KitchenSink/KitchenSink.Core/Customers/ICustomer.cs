using KitchenSink.Core.Agents;
using KitchenSink.Core.ContactInfo;
using KitchenSink.Core.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.Customers
{
    /*
     * 
     * Volatility high for customer information. Including details like eye color implies we will 
     * need extensible details.
     * 
     */ 
    public interface ICustomer : IPerson
    {
        IAgent Agent { get; set; }
        IList<IPhone> Phones { get; set; }
        IList<IEmail> Emails { get; set; }
        //This should probably be represented by transactions rather than a float
        //KISS for now.
        float Balance { get; set; }
        IList<string> Tags { get; set; }
    }
}
