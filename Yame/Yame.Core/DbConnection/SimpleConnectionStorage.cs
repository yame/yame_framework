using System;
using System.Collections.Generic;
using System.Data;

namespace Yame.Core
{
    public class SimpleConnectionStorage : IDbConnectionStorage
    {
        private readonly Dictionary<string, IDbConnection> storage = new Dictionary<string, IDbConnection>();

        /// <summary>
        /// 得到保存的所有连接
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDbConnection> GetAllDbConnections()
        {
            return storage.Values;
        }
        /// <summary>
        /// 得到指定KEY值的数据库连接
        /// </summary>
        /// <param name="dbKey"></param>
        /// <returns></returns>
        public IDbConnection GetDbConnectionForKey(string dbKey)
        {
            IDbConnection db;
            if( !storage.TryGetValue(dbKey, out db) )
            {
                return null;
            }

            return db;
        }
        /// <summary>
        /// 设置指定KEY值的数据为连接
        /// </summary>
        /// <param name="factoryKey"></param>
        /// <param name="connection"></param>
        public void SetDbConnectionForKey(string factoryKey, IDbConnection connection)
        {
            this.storage[factoryKey] = connection;
        }
    }
}
