using System.Threading.Tasks;

namespace KitchenSink.Core.Auth
{
    public interface IUserService
    {
        Task<IUser> Authenticate(string username, string password);
    }
}