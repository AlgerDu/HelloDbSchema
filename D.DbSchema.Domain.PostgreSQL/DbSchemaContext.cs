using D.DbSchema.PO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.Domain
{
    public class DbSchemaContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<ProjectVersion> ProjectVersions { get; set; }
        public DbSet<VersionTree> VersionTrees { get; set; }

        public DbSchemaContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
