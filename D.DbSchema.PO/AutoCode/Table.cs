using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.PO
{
    public partial class Table
    {
        public int ID { get; set; }

        public int No { get; set; }

        public int ProjectNo { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public int SortIndex { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        public bool IsStable { get; set; }

        public bool IsHistory { get; set; }
    }
}
