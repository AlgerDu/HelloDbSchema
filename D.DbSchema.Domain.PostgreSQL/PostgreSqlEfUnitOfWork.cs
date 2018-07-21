using D.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.Domain
{
    public class PostgreSqlEfUnitOfWork : BaseEFUnitOfWork
    {
        public DbSchemaContext DbSchemaContext => Context as DbSchemaContext;

        PostgreSqlEfUnitOfWork(
            ILogger<PostgreSqlEfUnitOfWork> logger
            , DbSchemaContext context)
            : base(context)
        {
            _logger = logger;
        }
    }
}
