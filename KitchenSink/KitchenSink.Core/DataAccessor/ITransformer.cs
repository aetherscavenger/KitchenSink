using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.DataAccessor
{
    public interface ITransformer<TOrigin, TDest>
    {
        TDest Transform(TOrigin from);
        TOrigin Transform(TDest from);
    }
}
