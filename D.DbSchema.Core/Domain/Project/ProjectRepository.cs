using D.DbSchema.Domain;
using D.DbSchema.PO;
using D.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D.DbSchema.Domain
{
    public class ProjectRepository :
        Repository<Project, int>
        , IProjectRepository
    {
        ILogger<ProjectRepository> _logger;

        public ProjectRepository(
            ILogger<ProjectRepository> logger
            , PostgreSqlEfUnitOfWork uow
            )
            : base(uow)
        {
            _logger = logger;
        }

        public Project FindByName(string name)
        {
            return Query().FirstOrDefault(pp => pp.Name == name && !pp.IsDelete);
        }

        public bool MarkDelete(Project entity)
        {
            entity.IsDelete = true;

            return Update(entity);
        }

        public bool MarkDelete(int No)
        {
            var entity = Query().FirstOrDefault(pp => !pp.IsDelete && pp.No == No);

            if (entity != null)
            {
                entity.IsDelete = true;
                entity.UpdateTime = DateTimeOffset.Now;

                return Update(entity);
            }
            else
            {
                return false;
            }
        }
    }
}
