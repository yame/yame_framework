using System;
using System.Web.Mvc;
using Yame.Core;
using System.Web;
using System.Security.Principal;
using Microsoft.Practices.ServiceLocation;

namespace Yame.Web
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeUserAttribute : FilterAttribute, IAuthorizationFilter
    {

        private readonly object _typeId = new object();
        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        // This method must be thread-safe since it is called by the thread-safe OnCacheAuthorization() method.
        protected virtual bool AuthorizeCore(HttpContextBase httpContext, AuthorizationContext filterContext)
        {
            if( httpContext == null )
            {
                throw new ArgumentNullException("httpContext");
            }

            IPrincipal user = httpContext.User;
            if( !user.Identity.IsAuthenticated )
            {
                return false;
            }
            string userName = user.Identity.Name;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;

            IAuthorizationProvider provider =  ServiceLocator.Current.GetInstance<IAuthorizationProvider>();
            if( provider == null )
            {
                throw new InformationException("没有提供用户鉴权【IAuthorizationProvider】的实现");
            }

            return provider.IsAuthorizedAction(userName, controllerName, actionName);
        }

        private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
        {
            validationStatus = OnCacheAuthorization(new HttpContextWrapper(context), (AuthorizationContext)data);
        }

        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            if( filterContext == null )
            {
                throw new ArgumentNullException("filterContext");
            }

            if( AuthorizeCore(filterContext.HttpContext, filterContext) )
            {
                // ** IMPORTANT **
                // Since we're performing authorization at the action level, the authorization code runs
                // after the output caching module. In the worst case this could allow an authorized user
                // to cause the page to be cached, then an unauthorized user would later be served the
                // cached page. We work around this by telling proxies not to cache the sensitive page,
                // then we hook our custom authorization code into the caching mechanism so that we have
                // the final say on whether a page should be served from the cache.

                HttpCachePolicyBase cachePolicy = filterContext.HttpContext.Response.Cache;
                cachePolicy.SetProxyMaxAge(new TimeSpan(0));
                cachePolicy.AddValidationCallback(CacheValidateHandler, filterContext);
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }

        protected virtual void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //如果Ajax请求
            if( filterContext.HttpContext.Request.IsAjaxRequest() )
            {
                filterContext.Result = new JsonNetResult(new JsonResultModel
                {
                    result = false,
                    message = "您没有权限操作！"
                });
            }
            else
            {
                // Returns HTTP 401 - see comment in HttpUnauthorizedResult.cs.
                filterContext.Result = new HttpUnauthorizedAndAjaxResult();
            }
        }

        // This method must be thread-safe since it is called by the caching module.
        protected virtual HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext, AuthorizationContext filterContext)
        {
            if( httpContext == null )
            {
                throw new ArgumentNullException("httpContext");
            }

            bool isAuthorized = AuthorizeCore(httpContext, filterContext);
            return (isAuthorized) ? HttpValidationStatus.Valid : HttpValidationStatus.IgnoreThisRequest;
        }

    }
}
