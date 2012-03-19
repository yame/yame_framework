using System;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace Yame.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class ComponentRegistrar
    {

        public static void AddComponentsTo(IWindsorContainer container)
        {
            //注册Yame.Data程序集中实现接口的类
            container.Register(
                AllTypes.Pick()
                .FromAssemblyNamed("Yame.Data")
                .WithService.FirstInterface());
        }
    }
}