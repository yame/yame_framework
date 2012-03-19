using System;
using System.Collections.Generic;
using System.Data;

namespace Yame.Core
{

    public class DbManager
    {
        private static readonly Dictionary<string, string> dbStrings =
           new Dictionary<string, string>();
        private static String defaultKey;

        public static IDbConnectionStorage Storage { get; set; }

        /// <summary>
        /// 设置默认的数据库连接
        /// </summary>
        /// <param name="key"></param>
        public static void SetDefaultKey(string key)
        {
            defaultKey = key;
        }

        /// <summary>
        /// 数据库创建工厂
        /// </summary>
        public static Func<string, IDbConnection> DbFactory { get; set; }

        /// <summary>
        /// 初始化数据库连接，如果有多个的话，可以调用这个多次
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="dbkey"></param>
        /// <param name="dbConnectionString"></param>
        public static void AddConnectionString(string dbkey, string dbConnectionString)
        {
            dbStrings.Add(dbkey, dbConnectionString);
        }

        /// <summary>
        /// 关闭所有连接
        /// </summary>
        public static void CloseAllConnections()
        {
            if( Storage != null )
            {
                foreach( IDbConnection db in Storage.GetAllDbConnections() )
                {
                    if( db.State == ConnectionState.Open )
                    {
                        db.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 得到指定Key值数据库连接
        /// </summary>
        /// <param name="dbKey"></param>
        /// <returns></returns>
        public static IDbConnection For(string dbKey)
        {
            IDbConnection dbConnection = Storage.GetDbConnectionForKey(dbKey);
            if( dbConnection == null )
            {
                dbConnection = DbFactory(dbStrings[dbKey]);
                dbConnection.Open();

                Storage.SetDbConnectionForKey(dbKey, dbConnection);
            }

            return dbConnection;
        }

        /// <summary>
        /// 得到默认的数据库
        /// </summary>
        /// <returns></returns>
        public static IDbConnection Default
        {
            get
            {
                return For(defaultKey);
            }
        }

    }
}