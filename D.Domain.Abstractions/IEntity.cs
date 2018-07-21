using System;
using System.Collections.Generic;
using System.Text;

namespace D.Domain
{
    /// <summary>
    /// 标识用接口
    /// </summary>
    public interface IEntity
    {
    }

    public interface IEntity<TPrimaryKey> : IEntity
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        TPrimaryKey PK { get; set; }

        bool IsTransient();
    }
}
