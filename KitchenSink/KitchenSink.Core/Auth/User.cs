using KitchenSink.Core.DataAccessor;

namespace KitchenSink.Core.Auth
{
    /// <summary>
    /// Let's KISS this implementation. No claims and nothing fancy.
    /// </summary>
    public sealed class User : IUser
    {
        //TODO: 20200115-00001
        //Normally we'd let a transformer handle this part. This was included only
        //to satisfy some of the KISS decisions up in the API. Revisit if we
        //end up setting up the transformer layer.
        public int _id { get { return Id; } set { Id = value; } }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public void Replace(IEntity replaceWithMe)
        {
            //Do nothing for users we are not managing them at this time.
            return;
        }
    }
}