using KitchenSink.Core.Auth;
using KitchenSink.Core.DataAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * Security volatility high, only interface basic auth for now. KISS implementation in the initial service.
 */
namespace KitchenSinkApi.Auth
{
    public class UserService : IUserService
    {
        private IDataAccessor _accessor;
        
        public UserService(IDataAccessor diMe)
        {
            _accessor = diMe;
        }
        public async Task<IUser> Authenticate(string username, string password)
        {
            var users = _accessor.Read<User>();
            var user = await Task.Run(() => users.SingleOrDefault(x => x.Username == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            //This is why "Credentials" vs "Identities" exist. You authenticate credentials, you return Identities
            //Punting security decisions, this was a KISS choice.
            return user.WithoutPassword();
        }
    }
}
