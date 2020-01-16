using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.DataAccessor
{
    public interface IEntity
    {
        int _id { get; set; }
        //Normally a data provider or data layer is in charge of merging.
        //I'm giving the entity the ability to do this for now since EF
        //frequently requires this type of pattern anyway.
        void Replace(IEntity replaceWithMe);
    }
}
