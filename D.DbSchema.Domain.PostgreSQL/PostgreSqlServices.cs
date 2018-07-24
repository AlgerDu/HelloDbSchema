using Autofac;
using D.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.Domain
{
    public static class PostgreSqlServices
    {
        public static void AddPostgreSQL(this ContainerBuilder builder, string connStr)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbSchemaContext>();
            optionsBuilder.UseNpgsql(connStr);

            builder.RegisterInstance(optionsBuilder.Options);

            builder.RegisterType<PostgreSqlEfUnitOfWork>()
                .As<IEFUnitOfWork>()
                .As<IUnitOfWorkRepositoryContext>()
                .As<IUnitOfWork>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<RepositoryFactory>()
                .As<IRepositoryFactory>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<UnitOfWorkFacoty>()
                .As<IUnitOfWorkFactory>()
                .AsSelf()
                .SingleInstance();
        }
    }
}
