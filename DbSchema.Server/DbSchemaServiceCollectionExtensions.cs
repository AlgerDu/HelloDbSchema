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
    public static class DbSchemaServiceCollectionExtensions
    {
        public static IServiceProvider AddDbSchema(
            this IServiceCollection services
            , IConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            services.AddDbContext<DbSchemaContext>();

            builder.Populate(services);

            builder.AddPostgreSQL(configuration.GetConnectionString("Default"));
            builder.AddDbSchemaDomain();

            return new AutofacServiceProvider(builder.Build());
        }
    }
}
