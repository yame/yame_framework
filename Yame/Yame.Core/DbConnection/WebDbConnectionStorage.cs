using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace Yame.Core
{
    public class WebDbConnectionStorage : IDbConnectionStorage
    {
        private const string HttpContextSessionStorageKey = "HttpContextSessionStorageKey";

        public WebDbConnectionStorage(HttpApplication app)
        {
            app.EndRequest += Application_EndRequest;
        }

        private static void Application_EndRequest(object sender, EventArgs e)
        {
            DbManager.CloseAllConnections();

            var context = HttpContext.Current;
            context.Items.Remove(HttpContextSessionStorageKey);
        }

        private static SimpleConnectionStorage GetSimpleSessionStorage()
        {
            var context = HttpContext.Current;
            var storage = context.Items[HttpContextSessionStorageKey] as SimpleConnectionStorage;
            if( storage == null )
            {
                storage = new SimpleConnectionStorage();
                context.Items[HttpContextSessionStorageKey] = storage;
            }

            return storage;
        }

        /// <summary>
        /// 得到保存的所有连接
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDbConnection> GetAllDbConnections()
        {
            SimpleConnectionStorage storage = GetSimpleSessionStorage();
            return storage.GetAllDbConnections();
        }
        /// <summary>
        /// 得到指定KEY值的数据库连接
        /// </summary>
        /// <param name="dbKey"></param>
        /// <returns></returns>
        public IDbConnection GetDbConnectionForKey(string dbKey)
        {
            SimpleConnectionStorage storage = GetSimpleSessionStorage();
            return storage.GetDbConnectionForKey(dbKey);
        }
        /// <summary>
        /// 设置指定KEY值的数据为连接
        /// </summary>
        /// <param name="dbKey"></param>
        /// <param name="db"></param>
        public void SetDbConnectionForKey(string dbKey, IDbConnection db)
        {
            SimpleConnectionStorage storage = GetSimpleSessionStorage();
            storage.SetDbConnectionForKey(dbKey, db);
        }
    }
}
