using D.DbSchema.PO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.Domain.Mappers
{
    internal class RelationshipCg : IEntityTypeConfiguration<Relationship>
    {
        public void Configure(EntityTypeBuilder<Relationship> builder)
        {
            builder.HasKey(e => e.ID);

            builder.Property(e => e.Name).HasMaxLength(64);
        }
    }
}
