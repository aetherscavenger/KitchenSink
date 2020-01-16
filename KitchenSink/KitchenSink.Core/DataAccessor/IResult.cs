using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.DataAccessor
{
    public interface IResult<T>
    {
        AccessorStatus Status { get; }
        T Payload { get; }
    }
}
