using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.Geo
{
    public interface IGeoSpatial
    {
        float Latitude { get; }
        float Longitude { get; }
    }
}
