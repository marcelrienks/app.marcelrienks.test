using System.Net;
using app.marcelrienks.test.Interfaces;
using app.marcelrienks.test.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace app.marcelrienks.test.Functions
{
    public class Dummy
    {
        private readonly ILogger _logger;
        private readonly IDummyService _dummyService;

        public Dummy(IDummyService dummyService, ILoggerFactory loggerFactory)
        {
            _dummyService = dummyService;
            _logger = loggerFactory.CreateLogger<Dummy>();
        }

        [Function("Dummy")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req, [FromBody]PostRequest postRequest)
        {
            _logger.LogInformation("entry...");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "Application/json");
            response.WriteString(_dummyService.PadMessage(postRequest.Message));

            return response;
        }
    }
}
