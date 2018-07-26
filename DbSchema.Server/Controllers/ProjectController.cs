using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbSchema.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        ILogger _logger;

        public ProjectController(
            ILogger<ProjectController> logger
            )
        {
            _logger = logger;
        }

        
    }
}
