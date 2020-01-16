using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.DataAccessor
{
    public interface IDataAccessor
    {
        IList<T> Read<T>() where T : IEntity;
        IList<T> Read<T>(IDictionary<string, object> parameters) where T : IEntity;
        IResult<T> Write<T>(T writeMe, IDictionary<string, object> parameters) where T : IEntity;
    }
}
