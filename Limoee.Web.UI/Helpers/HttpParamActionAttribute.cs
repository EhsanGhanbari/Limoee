using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Limoee.Web.UI.Helpers
{
    /// <summary>
    /// This attribute class is for handling multiple buttons in form
    /// http://stackoverflow.com/questions/5684711/multiple-submit-buttons-and-validation
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class HttpParamActionAttribute : ActionNameSelectorAttribute
    {
        public string Name { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request[Name] != null;
        }
    }
}