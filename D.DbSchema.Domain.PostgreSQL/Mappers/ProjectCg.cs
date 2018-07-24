using D.DbSchema.PO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.Domain.Mappers
{
    internal class ProjectCg : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(e => e.ID);

            builder.Property(e => e.Name).HasMaxLength(64);
            builder.Property(e => e.Remark).HasMaxLength(256);
        }
    }
}
