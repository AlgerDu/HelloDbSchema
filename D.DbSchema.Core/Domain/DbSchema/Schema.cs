using D.DbSchema.PO;
using D.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D.DbSchema.Domain
{
    //为了方便，快速
    public class Field : PO.Field
    {
        public IEnumerable<PO.FieldType> FieldTypes { get; set; }
    }

    public class Table : PO.Table
    {
        public IEnumerable<Field> Fields { get; set; }
    }

    /// <summary>
    /// 这个领域需要缓存起来，方便快速查找
    /// </summary>
    public class Schema :
        IAggregateRoot<int>
    {
        List<Table> _tables;
        ProjectVersion _version;

        /// <summary>
        /// 其实是对应的 Project 的 No
        /// </summary>
        public int PK
        {
            get => _version.ProjectNo;
            set
            {
                throw new Exception();
            }
        }

        public IEnumerable<Table> Tables => _tables.OrderBy(tt => tt.SortIndex);

        public PO.ProjectVersion Version => _version;

        public Table this[int tableNo]
        {
            get
            {
                return _tables.FirstOrDefault(tt => tt.No == tableNo);
            }
        }

        public Field this[int tableNo, int fieldNo]
        {
            get
            {
                return this[tableNo]?.Fields.FirstOrDefault(ff => ff.No == fieldNo);
            }
        }

        public Schema()
        {
            _tables = new List<Table>();
        }

        public bool IsTransient()
        {
            return PK == default(int);
        }
    }
}
