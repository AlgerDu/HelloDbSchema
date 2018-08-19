using D.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.Domain
{
    public interface ISchemaRepository :
        IRepository<Schema, int>
    {
    }
}
