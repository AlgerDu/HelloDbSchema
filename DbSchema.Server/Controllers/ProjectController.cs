using AutoMapper;
using D.DbSchema.Domain;
using D.DbSchema.PO;
using D.Domain;
using D.Utils;
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
        public IResult<NewProjectModel> AddProject([FromBody]ProjectAddModel projectAddModel)
        {
            var projectRepo = _repositoryFactory.Create<IProjectRepository>();

            var project = projectRepo.FindByName(projectAddModel.Name);

            if (project != null)
            {
                return Result.CreateError<NewProjectModel>("已经存在相同名称的项目");
            }

            var newProject = _mapper.Map<Project>(projectAddModel);

            projectRepo.Insert(newProject);

            if (projectRepo.Uow.Commit() != 1)
            {
                return Result.CreateError<NewProjectModel>("数据库保存失败");
            }

            newProject.No = newProject.ID;

            projectRepo.Update(newProject);

            if (projectRepo.Uow.Commit() != 1)
            {
                return Result.CreateError<NewProjectModel>("数据库保存失败");
            }

            return Result.CreateSuccess(_mapper.Map<NewProjectModel>(newProject));
        }
    }
}
