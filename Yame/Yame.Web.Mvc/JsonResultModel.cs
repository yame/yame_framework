using System;
using System.Web.Mvc;
using Yame.Core;
using System.Web;
using System.Security.Principal;

namespace Yame.Web
{
    public class JsonResultModel
    {
        public bool result { get; set; }
        public object date { get; set; }
        public string message { get; set; }
    }
}