using System;
using System.Web.Mvc;
using Yame.Core;
using System.Web;
using System.Security.Principal;
using Microsoft.Practices.ServiceLocation;

namespace Yame.Web
{
    /// <summary>
    /// 提供指定用户是否有权限操作指定Action
    /// </summary>
    public class AuthorizationProvider : IAuthorizationProvider
    {
        public AuthorizationProvider()
        {

        }
        /// <summary>
        /// 提供指定用户是否有权限操作指定Action
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="controllerName">控制类名称</param>
        /// <param name="actionName">Action名称</param>
        /// <returns>如果有权限，返回true,否则返回False</returns>
        public bool IsAuthorizedAction(string userName, string controllerName, string actionName)
        {
            throw new NotImplementedException();
        }
    }
}
