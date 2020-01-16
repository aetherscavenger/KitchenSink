using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.DataAccessor
{
    public static class EntityExtensions
    {
        public static IEntity ReplaceWith(this IEntity me, IEntity withMe)
        {
            var type = me.GetType();
            var props = type.GetProperties();
            foreach(var prop in props)
            {
                //Always skip the unique identifier.
                if (prop.Name == "_id")
                    continue;
                var replaceWith = prop.GetValue(withMe);
                prop.SetValue(me, replaceWith);
            }
            return me;
        }
    }
}
