using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D.DbSchema.Domain;
using D.DbSchema.PO;
using D.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DbSchema.Server.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        ILogger _logger;

        IUnitOfWorkFactory _uowFactory;
        IRepositoryFactory _repositoryFactory;

        public ValuesController(
            ILogger<ValuesController> logger
            , IUnitOfWorkFactory uowFactory
            , IRepositoryFactory repositoryFactory
            , DbSchemaContext dbSchemaContext
            )
        {
            _logger = logger;

            _uowFactory = uowFactory;
            _repositoryFactory = repositoryFactory;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _logger.LogInformation(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("project")]
        public Project GetProject()
        {
            _logger.LogInformation("test project");

            var repository = _repositoryFactory.Create<Project, int>();

            //var newP = new Project
            //{
            //    CreateTime = DateTimeOffset.Now,
            //    IsDelete = false,
            //    Remark = null,
            //    Name = "数据库管理",
            //    No = 1,
            //    UpdateTime = null
            //};

            //repository.Insert(newP);

            //var i = repository.Uow.Commit();

            //_logger.LogDebug($"提交成功的个数 {i}");

            var p = repository.Query().FirstOrDefault();

            return p;
        }
    }
}
