using System;
using System.Collections.Generic;
using System.Text;

namespace D.Domain
{
    public interface IUnitOfWorkRepositoryContext : IUnitOfWork
    {
        /// <summary>
        /// 将聚合根的状态标记为新建
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="obj"></param>
        bool RegisterNew<TEntity>(TEntity obj) where TEntity : class, IEntity;

        /// <summary>
        /// 将聚合根的状态标记为修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="obj"></param>
        bool RegisterModified<TEntity>(TEntity obj) where TEntity : class, IEntity;

        /// <summary>
        /// 将聚合根的状态标记为删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="obj"></param>
        bool RegisterDeleted<TEntity>(TEntity obj) where TEntity : class, IEntity;
    }
}
