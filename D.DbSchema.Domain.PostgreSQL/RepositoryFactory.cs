using Autofac;
using D.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.Domain
{
    public class RepositoryFactory : IRepositoryFactory
    {
        ILogger _logger;

        IUnitOfWorkFactory _uowFactory;
        ILifetimeScope _lifetimeScope;

        public RepositoryFactory(
            ILogger<RepositoryFactory> logger
            , IUnitOfWorkFactory uowFactory
            , ILifetimeScope lifetimeScope
            )
        {
            _logger = logger;

            _uowFactory = uowFactory;
            _lifetimeScope = lifetimeScope;
        }

        public IRepository<TEntity, TPrimaryKey> Create<TEntity, TPrimaryKey>(IUnitOfWork uow)
            where TEntity : class, IEntity<TPrimaryKey>
            where TPrimaryKey : IEquatable<TPrimaryKey>
        {
            using (var scope = _lifetimeScope.BeginLifetimeScope((builder) =>
            {
                builder.RegisterInstance(uow).As<IUnitOfWork>();
            }))
            {
                return scope.Resolve<IRepository<TEntity, TPrimaryKey>>();
            };
        }

        public TRepository Create<TRepository, TEntity, TPrimaryKey>(IUnitOfWork uow)
            where TRepository : IRepository<TEntity, TPrimaryKey>
            where TEntity : class, IEntity<TPrimaryKey>
            where TPrimaryKey : IEquatable<TPrimaryKey>
        {
            using (var scope = _lifetimeScope.BeginLifetimeScope((builder) =>
            {
                builder.RegisterInstance(uow).As<IUnitOfWork>();
            }))
            {
                return scope.Resolve<TRepository>();
            };
        }

        public IRepository<TEntity, TPrimaryKey> Create<TEntity, TPrimaryKey>()
            where TEntity : class, IEntity<TPrimaryKey>
            where TPrimaryKey : IEquatable<TPrimaryKey>
        {
            var uow = _uowFactory.Create();

            return Create<TEntity, TPrimaryKey>(uow);
        }

        public TRepository Create<TRepository, TEntity, TPrimaryKey>()
            where TRepository : IRepository<TEntity, TPrimaryKey>
            where TEntity : class, IEntity<TPrimaryKey>
            where TPrimaryKey : IEquatable<TPrimaryKey>
        {
            var uow = _uowFactory.Create();

            return Create<TRepository, TEntity, TPrimaryKey>(uow);
        }
    }
}
