using D.DbSchema.PO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.Domain.Mappers
{
    internal class ProjectVersionCg : IEntityTypeConfiguration<ProjectVersion>
    {
        public void Configure(EntityTypeBuilder<ProjectVersion> builder)
        {
            builder.HasKey(e => e.ID);

            builder.Property(e => e.VersionNo).HasMaxLength(64);
            builder.Property(e => e.Remark).HasMaxLength(256);
        }
    }
}
