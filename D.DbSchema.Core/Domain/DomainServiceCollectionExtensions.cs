using Autofac;
using D.DbSchema.PO;
using D.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.Domain
{
    public static class DomainServiceCollectionExtensions
    {
        /// <summary>
        /// 领域的一些服务
        /// </summary>
        /// <param name="builder"></param>
        public static void AddDbSchemaDomain(this ContainerBuilder builder)
        {
            builder.RegisterType<ProjectRepository>()
                .As<IProjectRepository>()
                .As<IRepository<Project, int>>()
                .AsSelf();
        }
    }
}
