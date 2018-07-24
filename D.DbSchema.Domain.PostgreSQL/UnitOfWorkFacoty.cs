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
        IComponentContext _componentContext;

        public UnitOfWorkFacoty(
            ILogger<UnitOfWorkFacoty> logger
            , ILifetimeScope lifetimeScope
            , IComponentContext componentContext
            )
        {
            _logger = logger;

            _lifetimeScope = lifetimeScope;
            _componentContext = componentContext;
        }

        public IUnitOfWork Create()
        {
            return _componentContext.Resolve<IUnitOfWork>();
        }
    }
}
