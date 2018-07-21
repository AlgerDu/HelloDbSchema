using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Domain
{
    /// <summary>
    /// EF 工作单元基类实现
    /// </summary>
    public abstract class BaseEFUnitOfWork : IEFUnitOfWork
    {
        DbContext _context;
        bool _isCommitted;

        IDbContextTransaction _transaction;

        protected ILogger _logger;

        public DbContext Context => _context;

        public bool IsCommitted => _isCommitted;

        public BaseEFUnitOfWork(
            DbContext context
            )
        {
            if (context == null) throw new Exception("BaseEFUnitOfWork IoC context is null");

            _context = context;
            _isCommitted = true;
        }

        public virtual int Commit()
        {
            if (!_isCommitted)
            {
                var lines = _context.SaveChanges();
                _transaction.Commit();

                _isCommitted = true;

                return lines;
            }
            else
            {
                return -1;
            }
        }

        public void Dispose()
        {
            Commit();
        }

        public virtual bool RegisterDeleted<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            IfCommitThenBeginTransaction();

            _context.Entry<TEntity>(entity).State = EntityState.Deleted;

            return true;
        }

        public virtual bool RegisterModified<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            IfCommitThenBeginTransaction();

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<TEntity>().Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Modified;

            return true;
        }

        public virtual bool RegisterNew<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            IfCommitThenBeginTransaction();

            var state = _context.Entry<TEntity>(entity).State;
            if (state == EntityState.Detached)
            {
                _context.Entry(entity).State = EntityState.Added;
            }

            return true;
        }

        public virtual void Rollback()
        {
            _transaction.Rollback();
        }

        /// <summary>
        /// 如果已经提交了，那么需要开启新的事务
        /// </summary>
        protected void IfCommitThenBeginTransaction()
        {
            if (_isCommitted)
            {
                lock (this)
                {
                    if (_isCommitted)
                    {
                        _isCommitted = false;
                        _transaction = _context.Database.BeginTransaction();
                    }
                }
            }
        }
    }
}
