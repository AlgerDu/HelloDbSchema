using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.PO
{
    public partial class Relationship
    {
        public int ID { get; set; }

        public int No { get; set; }

        public string Name { get; set; }

        public int ProjectNo { get; set; }

        public int MajorTableNo { get; set; }

        public int MajorTableFieldNo { get; set; }

        public int? MinorTableNo { get; set; }

        public int? MinorTableFieldNo { get; set; }

        public int RelationshipType { get; set; }

        public int SortIndex { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        public bool IsStable { get; set; }

        public bool IsHistory { get; set; }
    }
}
