using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D.Domain
{
    /// <summary>
    /// 通用仓储，用于基类和一些需要简单对待的数据库模型
    /// </summary>
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        protected IEFUnitOfWork _efUOW;

        protected DbSet<TEntity> _entitys;

        public IUnitOfWork Uow => _efUOW;

        public Repository(
            IEFUnitOfWork uow
            )
        {
            _efUOW = uow;
            _entitys = _efUOW.Context.Set<TEntity>();
        }

        public virtual bool Delete(TPrimaryKey key)
        {
            var entity = _entitys.FirstOrDefault(ee => ee.PK.Equals(key));

            return Delete(entity);
        }

        public virtual bool Delete(TEntity entity)
        {
            _efUOW.RegisterDeleted(entity);

            return true;
        }

        public virtual void Dispose()
        {
            _efUOW.Dispose();
        }

        public virtual TEntity GetByKey(TPrimaryKey key)
        {
            return _entitys.FirstOrDefault(ee => ee.PK.Equals(key));
        }

        public virtual bool Insert(TEntity entity)
        {
            _efUOW.RegisterNew(entity);

            return true;
        }

        public virtual IQueryable<TEntity> Query()
        {
            return _entitys;
        }

        public virtual int SaveChange()
        {
            return _efUOW.Context.SaveChanges();
        }

        public virtual bool Update(TEntity entity)
        {
            _efUOW.RegisterModified(entity);

            return true;
        }
    }
}
