using System;
using System.Collections.Generic;
using System.Text;

namespace D.Domain
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity, TPrimaryKey> Create<TEntity, TPrimaryKey>(IUnitOfWork uow)
            where TEntity : class, IEntity<TPrimaryKey>
            where TPrimaryKey : IEquatable<TPrimaryKey>;

        TRepository Create<TRepository>(IUnitOfWork uow)
            where TRepository : IRepository;


        IRepository<TEntity, TPrimaryKey> Create<TEntity, TPrimaryKey>()
            where TEntity : class, IEntity<TPrimaryKey>
            where TPrimaryKey : IEquatable<TPrimaryKey>;

        TRepository Create<TRepository>()
            where TRepository : IRepository;
    }
}
