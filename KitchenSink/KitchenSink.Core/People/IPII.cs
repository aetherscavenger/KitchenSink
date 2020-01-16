using KitchenSink.Core.Auth;
using System.Collections.Generic;

namespace KitchenSink.Core.People
{
    public interface IPII
    {
        IPII Decrypt(ICrypto crypto);

        IPII Encrypt(ICrypto crypto);

        IPII Obfuscate(IDictionary<string, string> parameters);
    }
}