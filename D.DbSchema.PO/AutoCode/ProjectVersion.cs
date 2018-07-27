using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.PO
{
    public partial class ProjectVersion
    {
        public int ID { get; set; }

        public string VersionNo { get; set; }

        public string Remark { get; set; }

        public int ProjectNo { get; set; }

        public string SourceVersionNo { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        public DateTimeOffset? UpdateTime { get; set; }

        public bool IsStable { get; set; }
    }
}
