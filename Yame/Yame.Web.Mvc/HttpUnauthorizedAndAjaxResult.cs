using System;
using System.Web.Mvc;
using Yame.Core;
using System.Web;
using System.Security.Principal;
using Microsoft.Practices.ServiceLocation;

namespace Yame.Web
{
    /// <summary>
    /// 表示未鉴权的请求结果
    /// </summary>
    public class HttpUnauthorizedAndAjaxResult : ActionResult
    {

        public override void ExecuteResult(ControllerContext context)
        {
            if( context == null )
            {
                throw new ArgumentNullException("context");
            }

            // HTTP 401 is the status code for unauthorized access. Other code might
            // intercept this and perform some special logic. For example, the
            // FormsAuthenticationModule looks for 401 responses and instead redirects
            // the user to the login page.
            context.HttpContext.Response.StatusCode = 401;
        }
    }
}
