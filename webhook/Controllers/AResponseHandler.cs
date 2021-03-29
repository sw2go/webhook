using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webhook.Controllers
{
    /// <summary>
    /// Base Class For All Handlers
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    [ApiController, Route("{prefix:webhookRoutePrefix}/[controller]")]
    public abstract class ResponseHandler<TRequest, TResponse>
    {
        [HttpPost, Route("")]
        public abstract Task<TResponse> Handle([FromBody] TRequest request);
    }
}
