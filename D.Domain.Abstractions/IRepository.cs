using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D.Domain
{
    public interface IRepository<TEntity, TPrimaryKey> : IDisposable
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        IUnitOfWork Uow { get; }

        /// <summary>
        /// 简单通用查询
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> Query();

        bool Insert(TEntity entity);

        bool Delete(TPrimaryKey key);

        bool Delete(TEntity entity);

        bool Update(TEntity entity);

        TEntity GetByKey(TPrimaryKey key);

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <returns></returns>
        int SaveChange();
    }
}
