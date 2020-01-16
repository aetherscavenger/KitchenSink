using KitchenSink.Core.Auth;
using KitchenSink.Core.People;
using System;
using System.Collections.Generic;

namespace KitchenSink.Core.ContactInfo
{
    public class Email : IEmail
    {
        public string Value { get; set; }
        public string EncryptedPayload { get; set; }
        public ContactType Type { get; set; }
        public IPII Decrypt(ICrypto crypto)
        {
            throw new NotImplementedException();
        }

        public IPII Encrypt(ICrypto crypto)
        {
            throw new NotImplementedException();
        }

        public IPII Obfuscate(IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}