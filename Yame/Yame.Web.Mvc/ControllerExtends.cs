using System;
using System.Web.Mvc;
using Yame.Core;

namespace Yame.Web
{
    public static class ControllerExtends
    {
        /// <summary>
        /// 执行操作后，得到输出到客户端的数据
        /// </summary>
        /// <param name="action">执行的操作</param>
        /// <returns></returns>
        public static JsonResultModel HandlerInvokeMethod(this Controller controller, Action<JsonResultModel> action)
        {
            var result = new JsonResultModel();
            try
            {
                action(result);
                result.result = true;
            }
            catch( InformationException ie )
            {
                result.message = ie.Message;
            }
            catch( Exception ex )
            {
                result.message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// 返回Json结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controller"></param>
        /// <param name="data">返回的数据</param>
        /// <returns></returns>
        public static ActionResult JsonNet<T>(this Controller controller, T data)
        {
            return new JsonNetResult(data);
        }
    }
}