using KitchenSink.Core.DataAccessor;

namespace KitchenSink.Core.Auth
{
    public interface IUser : IEntity
    {
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string Username { get; set; }
    }
}