using System;
using System.Collections.Generic;
using System.Text;

namespace D.Domain
{
    public interface IAggregateRoot
    {
    }

    public interface IAggregateRoot<TPrimaryKey> : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {

    }
}
