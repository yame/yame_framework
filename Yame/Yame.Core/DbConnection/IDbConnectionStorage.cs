using System;
using System.Collections.Generic;
using System.Data;

namespace Yame.Core
{
    /// <summary>
    /// 存储数据库连接
    /// </summary>
    public interface IDbConnectionStorage
    {
        /// <summary>
        /// 得到保存的所有连接
        /// </summary>
        /// <returns></returns>
        IEnumerable<IDbConnection> GetAllDbConnections();

        /// <summary>
        /// 得到指定KEY值的数据库连接
        /// </summary>
        /// <param name="dbKey"></param>
        /// <returns></returns>
        IDbConnection GetDbConnectionForKey(string dbKey);

        /// <summary>
        /// 设置指定KEY值的数据为连接
        /// </summary>
        /// <param name="dbKey"></param>
        /// <param name="db"></param>
        void SetDbConnectionForKey(string dbKey, IDbConnection db);
    }
}