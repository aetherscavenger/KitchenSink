using KitchenSink.Core.Agents;
using KitchenSink.Core.ContactInfo;
using KitchenSink.Core.DataAccessor;
using KitchenSink.Core.Geo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenSinkApi.PersistenceEmulator.DataSourceOne.Transformers
{
    public class AgentsTransformer<TOrigin, TDest> : ITransformer<TOrigin, TDest>
        where TOrigin : Agents
        where TDest : Agent
    {
        public TDest Transform(TOrigin from)
        {
            var returnMe = new Agent();

            returnMe._id = from._id;
            returnMe.DisplayName = from.Name;

            //Smaller transformers are appropriate here.
            //Refactor later.
            returnMe.Address = new Address
            {
                AddressLine1 = from.Address,
                City = from.City,
                PostalCode = from.ZipCode,
                StateProvince = from.State
            };
            returnMe.Phones = new List<Phone>();
            returnMe.Phones.Add(new Phone { Number = from.Phone.Primary, Type = ContactType.Primary });
            returnMe.Phones.Add(new Phone { Number = from.Phone.Mobile, Type = ContactType.Mobile });

            returnMe.Tier = from.Tier;

            return (TDest)returnMe;
        }

        public TOrigin Transform(TDest from)
        {
            var returnMe = new Agents();

            returnMe._id = from._id;
            returnMe.Name = from.DisplayName;

            //Smaller transformers are appropriate here.
            //Refactor later.
            returnMe.Address = from.Address.AddressLine1;
            returnMe.City = from.Address.City;
            returnMe.State = from.Address.StateProvince;
            returnMe.ZipCode = from.Address.PostalCode;

            returnMe.Tier = from.Tier;
            returnMe.Phone = new PhoneDTO();
            returnMe.Phone.Primary = from.Phones.FirstOrDefault(p=>p.Type == ContactType.Primary).Number;
            returnMe.Phone.Mobile = from.Phones.FirstOrDefault(p => p.Type == ContactType.Mobile).Number;

            return (TOrigin)returnMe;
        }
    }
}