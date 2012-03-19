using System;
using System.Collections.Generic;
using System.Data;

namespace Yame.Core
{
    public class SimpleConnectionStorage : IDbConnectionStorage
    {
        private readonly Dictionary<string, IDbConnection> storage = new Dictionary<string, IDbConnection>();

        /// <summary>
        /// �õ��������������
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDbConnection> GetAllDbConnections()
        {
            return storage.Values;
        }
        /// <summary>
        /// �õ�ָ��KEYֵ�����ݿ�����
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
        /// ����ָ��KEYֵ������Ϊ����
        /// </summary>
        /// <param name="factoryKey"></param>
        /// <param name="connection"></param>
        public void SetDbConnectionForKey(string factoryKey, IDbConnection connection)
        {
            this.storage[factoryKey] = connection;
        }
    }
}
