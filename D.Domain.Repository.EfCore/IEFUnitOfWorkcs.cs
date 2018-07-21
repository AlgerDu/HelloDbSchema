using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Domain
{
    /// <summary>
    /// EF 工作单元
    /// </summary>
    public interface IEFUnitOfWork : IUnitOfWorkRepositoryContext
    {
        DbContext Context { get; }
    }
}
