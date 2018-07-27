using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbSchema.Server.Models
{
    public class ProjectAddModel
    {
        [StringLength(64, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }
    }
}
