using D.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.PO
{
    /// <summary>
    /// 项目
    /// </summary>
    public partial class Project
    {
        public int ID { get; set; }

        /// <summary>
        /// 项目编号，主键；
        /// 暂时不对外开放修改
        /// </summary>
        public int No { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        public DateTimeOffset? UpdateTime { get; set; }

        public bool IsDelete { get; set; }
    }
}
