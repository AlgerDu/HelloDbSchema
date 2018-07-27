using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.PO
{
    public partial class VersionTree
    {
        public int NodeID { get; set; }

        public int ParentNodeID { get; set; }

        public int NodeType { get; set; }

        public int RelationID { get; set; }
    }
}
