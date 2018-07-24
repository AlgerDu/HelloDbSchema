using D.DbSchema.PO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.Domain.Mappers
{
    internal class VersionTreeCg : IEntityTypeConfiguration<VersionTree>
    {
        public void Configure(EntityTypeBuilder<VersionTree> builder)
        {
            builder.HasKey(e => e.NodeID);
        }
    }
}
