using Microsoft.AspNetCore.Mvc;

namespace Ansibility.Web.Common
{
    public class SmallCamelRouteAttribute : RouteAttribute
    {
        public SmallCamelRouteAttribute(string controllerName)
            : base(
                Constants.ApiPathBase + controllerName.Replace(nameof(Controller), string.Empty)[0].ToString().ToLower() +
                controllerName.Substring(1).Replace(nameof(Controller), string.Empty))
        {
        }
    }
}