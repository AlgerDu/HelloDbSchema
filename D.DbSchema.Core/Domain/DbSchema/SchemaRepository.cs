using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D.Domain;
using Microsoft.Extensions.Logging;

namespace D.DbSchema.Domain
{
    public class SchemaRepository
        : ISchemaRepository
    {
        ILogger _logger;
        PostgreSqlEfUnitOfWork _uow;

        public IUnitOfWork Uow => _uow;

        public SchemaRepository(
            ILogger<SchemaRepository> logger
            , PostgreSqlEfUnitOfWork uow
            )
        {
            _logger = logger;
            _uow = uow;
        }

        public bool Delete(int key)
        {
            throw new Exception("DbSchemaRepository Delete 不应该被调用到");
        }

        public bool Delete(Schema entity)
        {
            throw new Exception("DbSchemaRepository Delete 不应该被调用到");
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        public Schema GetByKey(int key)
        {
            //TODO 检查数据的完善性

            var context = _uow.DbSchemaContext;

            var project = context.Projects.FirstOrDefault(pp => pp.No == key);

            if (project == null)
                return null;

            var schema = new Schema() { PK = key };

            var tables = context.Tables
                .Where(tt =>
                tt.ProjectNo == key
                && !tt.IsHistory
                );

            foreach (var table in tables)
            {
                schema[table.No] = table;
            }

            var fields = context.Fields
                .Where(ff =>
                    ff.ProjectNo == key
                    && !ff.IsHistory
                );

            foreach (var field in fields)
            {
                schema[field.TableNo, field.No] = field;
            }

            return schema;
        }

        public bool Insert(Schema entity)
        {
            var context = _uow.DbSchemaContext;

            var project = context.Projects.FirstOrDefault(pp => pp.No == entity.PK);
        }

        public IQueryable<Schema> Query()
        {
            throw new Exception("DbSchemaRepository Query 不应该被调用到");
        }

        public int SaveChange()
        {
            return _uow.Commit();
        }

        public bool Update(Schema entity)
        {
            throw new NotImplementedException();
        }
    }
}
