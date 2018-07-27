using D.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace D.DbSchema.PO
{
    public partial class Project : IEntity<int>
    {
        [NotMapped]
        public int PK
        {
            get => ID;
            set => ID = value;
        }

        public bool IsTransient()
        {
            return PK == default(int);
        }
    }
}
