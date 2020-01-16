using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.ContactInfo
{
    public class Phone : IPhone
    {
        public bool CanSms { get; set; }
        public string Extension { get; set; }
        public string Number { get; set; }
        public bool OptInSms { get; set; }
        public ContactType Type { get; set; }
    }
}
