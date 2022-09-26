using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ParamConstraints
{
    public class CustomConstraints : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey,out object parameterValue))
            {
                if(parameterValue is string value)
                {
                   return value.StartsWith("sa");
                }
            }
            return false;
        }
    }
}
