using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.Auth
{
    public static class UserExtensions
    {
        public const string Obfuscate = "*********";
        public static IUser WithoutPassword(this IUser user)
        {
            user.Password = Obfuscate;
            return user;
        }
    }
}
