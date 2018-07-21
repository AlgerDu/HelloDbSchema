using System;
using System.Collections.Generic;
using System.Text;

namespace D.Domain
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
