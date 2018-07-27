using AutoMapper;
using DbSchema.Server.Models;
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
        IMapper _mapper;

        public ProjectController(
            ILogger<ProjectController> logger
            , IMapper mapper
            )
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public int AddProject([FromBody]ProjectAddModel projectAddModel)
        {
            return 0;
        }
    }
}
