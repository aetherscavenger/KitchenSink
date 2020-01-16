using System;
using System.Collections.Generic;

namespace KitchenSink.Core.People
{
    public interface IPerson : IPII
    {
        DateTime? BirthDate { get; set; }
        IList<KvP<string, string>> Characteristics { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string PreferredName { get; set; }
    }
}