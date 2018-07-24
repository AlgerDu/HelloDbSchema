using Autofac;
using Autofac.Extensions.DependencyInjection;
using D.DbSchema.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbSchema.Server
{
    public static class DbSchemaService
    {
        public static IServiceProvider AddDbSchema(
            this IServiceCollection services
            , IConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            services.AddDbContext<DbSchemaContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("Default"))
                );

            builder.Populate(services);

            //builder.RegisterType<DbSchemaContext>()
            //    .As<DbContext>()
            //    .AsSelf();

            builder.AddPostgreSQL(configuration.GetConnectionString("Default"));

            return new AutofacServiceProvider(builder.Build());
        }
    }
}
