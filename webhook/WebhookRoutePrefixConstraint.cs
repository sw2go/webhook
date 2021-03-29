using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webhook
{
    public class WebhookRoutePrefixConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue("prefix", out var value) && value is string actual)
            {
                var options = (WebhookOptions)httpContext?
                    .RequestServices
                    .GetService(typeof(WebhookOptions));
                // urls are case sensitive
                var expected = options?.RoutePrefix;
                return expected == actual;
            }
            return false;
        }
    }
}
