using D.DbSchema.PO;
using D.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D.DbSchema.Domain
{
    /// <summary>
    /// 这个领域需要缓存起来，方便快速查找
    /// </summary>
    public class DbSchema :
        IAggregateRoot<int>
    {
        List<Table> _tables;

        List<Field> _fields;

        /// <summary>
        /// 其实是对应的 Project 的 No
        /// </summary>
        public int PK { get; set; }

        public IEnumerable<Table> Tables => _tables.OrderBy(tt => tt.SortIndex);

        public IEnumerable<Field> Fields => _fields.OrderBy(ff => ff.TableNo).OrderBy(ff => ff.SortIndex);

        public Table this[int tableNo]
        {
            get
            {
                return _tables.FirstOrDefault(tt => tt.No == tableNo);
            }

            set
            {
                var old = _tables.FirstOrDefault(tt => tt.No == tableNo);

                if (old != null)
                {
                    _tables.Remove(old);
                }

                _tables.Add(value);
            }
        }

        public Field this[int tableNo, int fieldNo]
        {
            get
            {
                return _fields.FirstOrDefault(ff => ff.TableNo == tableNo && ff.No == fieldNo);
            }

            set
            {
                var old = _fields.FirstOrDefault(ff => ff.TableNo == tableNo && ff.No == fieldNo);

                if (old != null)
                {
                    _fields.Remove(old);
                }

                _fields.Add(value);
            }
        }

        public DbSchema()
        {
            _tables = new List<Table>();
            _fields = new List<Field>();
        }

        public bool IsTransient()
        {
            return PK == default(int);
        }
    }
}
