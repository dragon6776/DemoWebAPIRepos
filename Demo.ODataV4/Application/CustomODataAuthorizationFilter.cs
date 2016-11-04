using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Demo.ODataV4.Application
{
    public class CustomODataAuthorizationFilter : IAuthorizationFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            if(actionContext.Request.Headers.Authorization == null)
            {
                return Task.Run(() => new HttpResponseMessage
                {
                    Content = new StringContent(""),
                    ReasonPhrase = "Chưa xác thực",
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                });
            }

            return continuation();
        }
    }
}