using AutoMapper;
using D.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbSchema.Server.Controllers
{
    public class DbSchemaController : Controller
    {
        ILogger _logger;
        IMapper _mapper;

        IUnitOfWorkFactory _uowFactory;
        IRepositoryFactory _repositoryFactory;

        public DbSchemaController(
            ILogger<DbSchemaController> logger
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
    }
}
