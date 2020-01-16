using KitchenSink.Core.Agents;
using KitchenSink.Core.ContactInfo;
using KitchenSink.Core.Customers;
using KitchenSink.Core.DataAccessor;
using KitchenSink.Core.Geo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace KitchenSinkApi.PersistenceEmulator.DataSourceOne.Transformers
{
    public class CustomerTransformer<TOrigin, TDest> : ITransformer<TOrigin, TDest>
        where TOrigin : Customers
        where TDest : Customer
    {
        public TDest Transform(TOrigin from)
        {
            var returnMe = new Customer();

            //Keep this slip, let the view model grab the details
            returnMe.Agent = new Agent { _id = from.AgentId }; 
            returnMe.Balance = float.Parse(from.Balance, NumberStyles.AllowCurrencySymbol | NumberStyles.Currency);
            returnMe.Characteristics = new Dictionary<string, string>();
            returnMe.Characteristics.Add("Age", from.Age.ToString());
            returnMe.Characteristics.Add("EyeColor", from.EyeColor);
            returnMe.Emails


            return (TDest)returnMe;
        }

        public TOrigin Transform(TDest from)
        {
            throw new NotImplementedException();
        }
    }
}
