using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;

namespace app.marcelrienks.test.Functions
{
    public class AuthedDummy
    {
        private readonly ILogger _logger;

        public AuthedDummy(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AuthedDummy>();
        }

        [RequiredScope("test")]
        [Function("AuthedDummy")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            return response;
        }
    }
}
