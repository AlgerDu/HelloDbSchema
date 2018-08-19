using D.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace D.DbSchema.PO
{
    public partial class Table
        : IEntity<int>
        , ISchemaCheckChange<Table>
    {
        [NotMapped]
        public int PK
        {
            get => ID;
            set => ID = value;
        }

        public bool Changed(Table left)
        {
            return (
                   Name != left.Name
                || Remark != left.Remark
                || SortIndex != left.SortIndex
                );
        }

        public bool IsTransient()
        {
            return PK == default(int);
        }
    }

    public partial class Field
        : IEntity<int>
        , ISchemaCheckChange<Field>
    {
        [NotMapped]
        public int PK
        {
            get => ID;
            set => ID = value;
        }

        public bool Changed(Field left)
        {
            return (
                Name != left.Name
                || Length != left.Length
                || Nullable != left.Nullable
                || Remark != left.Remark
                || SortIndex != left.SortIndex
                );
        }

        public bool IsTransient()
        {
            return PK == default(int);
        }
    }
}
