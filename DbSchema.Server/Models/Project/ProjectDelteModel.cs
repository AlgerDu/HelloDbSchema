using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbSchema.Server.Models
{
    public class ProjectDelteModel
    {
        [Required]
        public int ProjectNo { get; set; }
    }
}
