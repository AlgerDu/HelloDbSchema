using AutoMapper;
using D.DbSchema.Domain;
using D.DbSchema.PO;
using D.Domain;
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

        IUnitOfWorkFactory _uowFactory;
        IRepositoryFactory _repositoryFactory;

        public ProjectController(
            ILogger<ProjectController> logger
            , IMapper mapper
            , IUnitOfWorkFactory uowFactory
            , IRepositoryFactory repositoryFactory
            )
        {
            _logger = logger;
            _mapper = mapper;

            _uowFactory = uowFactory;
            _repositoryFactory = repositoryFactory;
        }

        [HttpPost("add")]
        public int AddProject([FromBody]ProjectAddModel projectAddModel)
        {
            var newProject = _mapper.Map<Project>(projectAddModel);

            var projectRepo = _repositoryFactory.Create<IProjectRepository>();

            var hasProject = projectRepo.FindByName(newProject.Name) != null;

            return hasProject ? 1 : 0;
        }
    }
}
