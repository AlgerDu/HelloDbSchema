using Autofac;
using D.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.Domain
{
    public class UnitOfWorkFacoty : IUnitOfWorkFactory
    {
        ILogger _logger;

        ILifetimeScope _lifetimeScope;

        public UnitOfWorkFacoty(
            ILogger<UnitOfWorkFacoty> logger
            , ILifetimeScope lifetimeScope
            )
        {
            _logger = logger;

            _lifetimeScope = lifetimeScope;
        }

        public IUnitOfWork Create()
        {
            return _lifetimeScope.Resolve<IUnitOfWork>();
        }
    }
}
