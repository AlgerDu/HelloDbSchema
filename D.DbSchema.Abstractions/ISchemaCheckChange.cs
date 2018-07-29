using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema
{
    public interface ISchemaCheckChange<TEntity>
    {
        bool Changed(TEntity left);
    }
}
