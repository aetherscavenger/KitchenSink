using KitchenSink.Core.Agents;
using KitchenSink.Core.Auth;
using KitchenSink.Core.ContactInfo;
using KitchenSink.Core.People;
using System;
using System.Collections.Generic;

namespace KitchenSink.Core.Customers
{
    public class Customer : ICustomer
    {
        private const string OBFUSCATE = "****";
        public IAgent Agent { get; set; }
        public float Balance { get; set; }
        public DateTime? BirthDate { get; set; }
        public IDictionary<string, string> Characteristics { get; set; }
        public IList<IEmail> Emails { get; set; }
        public string EncryptedPayload { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public IList<IPhone> Phones { get; set; }
        public string PreferredName { get; set; }
        public IList<string> Tags { get; set; }

        public IPII Decrypt(ICrypto crypto)
        {
            return (IPII)crypto.Decrypt(EncryptedPayload);
        }

        public IPII Encrypt(ICrypto crypto)
        {
            EncryptedPayload = crypto.Encrypt(this);
            return this;
        }

        public IPII Obfuscate(IDictionary<string, string> parameters)
        {
            //TODO: 20200116-00002: Switch from string, string to string, object and
            //create SafeCast
            foreach (var param in parameters)
            {
                var prop = GetType().GetProperty(param.Key);
                if (prop.PropertyType == typeof(string))
                    prop.SetValue(this, param.Value);
            }
            FirstName = OBFUSCATE;
            MiddleName = OBFUSCATE;
            LastName = OBFUSCATE;
            return this;
        }
    }
}