using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.PO
{
    public partial class FieldType
    {
        public int ID { get; set; }

        public int FieldNo { get; set; }

        public int ProjectNo { get; set; }

        public int TableNo { get; set; }

        public int DbType { get; set; }

        public int DbFieldType { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        public bool IsStable { get; set; }

        public bool IsHistory { get; set; }
    }
}
