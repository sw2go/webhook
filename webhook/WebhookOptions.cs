using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webhook
{
    public class WebhookOptions
    {
        public string RoutePrefix { get; set; } = "webhooks";


    }

    public static class xxx
    {
        public static IServiceCollection AddWebhooks(this IServiceCollection services, Action<WebhookOptions> spaceAction = null)
        {
            var options = new WebhookOptions();

            services.Configure<RouteOptions>(opt =>
            {
                opt.ConstraintMap.Add("webhookRoutePrefix", typeof(WebhookRoutePrefixConstraint));
            });
            spaceAction?.Invoke(options);
            services.AddSingleton(options);

            return services;
        }
    }


}
