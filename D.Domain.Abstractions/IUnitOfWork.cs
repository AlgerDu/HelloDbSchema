using System;
using System.Collections.Generic;
using System.Text;

namespace D.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsCommitted { get; }

        /// <summary>
        /// 暂定：只能被 commit 1 次；
        /// 提交成功，返回 >= 0;
        /// 已经提交 -1；
        /// 提交出现异常 -2
        /// </summary>
        /// <returns></returns>
        int Commit();

        void Rollback();
    }
}
