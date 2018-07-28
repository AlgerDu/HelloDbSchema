using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbSchema.Server.Models
{
    public class NewProjectModel
    {
        public int No { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        public DateTimeOffset? UpdateTime { get; set; }
    }
}
