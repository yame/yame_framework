using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Yame.Core;
using System.Configuration;
using System.Reflection;
using Castle.Windsor;
using Yame.Web.Controllers;
using Microsoft.Practices.ServiceLocation;
using CommonServiceLocator.WindsorAdapter;
using MvcContrib.Castle;

namespace Yame.Web
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new string[] { "Yame.Web.Controllers" }
            );

        }

        public override void Init()
        {
            base.Init();

            webConnectionStorage = new WebDbConnectionStorage(this);
        }

        private IDbConnectionStorage webConnectionStorage;

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();

            //ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new AreaViewEngine());
            //支持Json请求
            ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());

            IWindsorContainer container = InitializeServiceLocator();

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        private IWindsorContainer InitializeServiceLocator()
        {
            IWindsorContainer container = new WindsorContainer();
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));

            container.RegisterControllers(typeof(HomeController).Assembly);
            ComponentRegistrar.AddComponentsTo(container);

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));

            return container;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Initializer.Instance().InitializeOnce(() => InitializeDbConnection());
        }

        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        private void InitializeDbConnection()
        {
            //初始化数据库连接字符
            foreach( ConnectionStringSettings item in ConfigurationManager.ConnectionStrings )
            {
                DbManager.AddConnectionString(item.Name, item.ConnectionString);
            }
            DbManager.DbFactory = (str) => new System.Data.SqlClient.SqlConnection(str);
            DbManager.Storage = webConnectionStorage;
            DbManager.SetDefaultKey(DBNames.DefaultName);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Useful for debugging
            Exception ex = Server.GetLastError();
            ReflectionTypeLoadException reflectionTypeLoadException = ex as ReflectionTypeLoadException;
        }
    }
}