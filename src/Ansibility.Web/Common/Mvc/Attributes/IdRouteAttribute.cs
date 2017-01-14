using Microsoft.AspNetCore.Mvc;

namespace Ansibility.Web.Common.Mvc.Attributes
{
    public class IdRouteAttribute : RouteAttribute
    {
        public IdRouteAttribute() : base("{id}")
        {
        }
    }
}