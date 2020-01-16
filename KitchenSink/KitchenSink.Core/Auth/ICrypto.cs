using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.Auth
{
    public interface ICrypto
    {
        //Another bit of over engineering
        string Encrypt(object encryptMe);
        object Decrypt(string decryptMe);
    }
}
