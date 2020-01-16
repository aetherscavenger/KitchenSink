using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.DataAccessor
{
    public class Result<T> : IResult<T>
    {
        public Result(AccessorStatus status, T payload)
        {
            Status = status;
            Payload = payload;
        }

        public AccessorStatus Status { get; }

        public T Payload { get; }
    }
}
