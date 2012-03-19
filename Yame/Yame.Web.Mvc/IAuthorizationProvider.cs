using System;
using System.Web.Mvc;
using Yame.Core;
using System.Web;
using System.Security.Principal;
using Microsoft.Practices.ServiceLocation;

namespace Yame.Web
{
    /// <summary>
    /// �ṩָ���û��Ƿ���Ȩ�޲���ָ��Action
    /// </summary>
    public interface IAuthorizationProvider
    {
        /// <summary>
        /// �ṩָ���û��Ƿ���Ȩ�޲���ָ��Action
        /// </summary>
        /// <param name="userName">�û���</param>
        /// <param name="controllerName">����������</param>
        /// <param name="actionName">Action����</param>
        /// <returns>�����Ȩ�ޣ�����true,���򷵻�False</returns>
        bool IsAuthorizedAction(string userName, string controllerName, string actionName);
    }
}
