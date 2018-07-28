using D.DbSchema.PO;
using D.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.DbSchema.Domain
{
    public interface IProjectRepository :
        IRepository<Project, int>
    {
        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool MarkDelete(Project entity);

        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="PK"></param>
        /// <returns></returns>
        bool MarkDelete(int No);

        /// <summary>
        /// 通过名称查找
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Project FindByName(string name);
    }
}
