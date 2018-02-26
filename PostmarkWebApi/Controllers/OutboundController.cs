using System.Net;
using System.Net.Http;
using System.Web.Http;
using PostmarkWebApi.BusinessLogic;
using PostmarkWebApi.Communication;
using PostmarkWebApi.Configuration;
using PostmarkWebApi.DA;
using PostmarkWebApi.Helpers;
using PostmarkWebApi.Models;

namespace PostmarkWebApi.Controllers
{
    public class OutboundController : ApiController
    {
        private readonly IMailboxManager _mailBoxManager;

        public OutboundController()
        {
            IMailboxRepository mailBoxRepository = new MailboxRepository();
            IPostmarkClientFactory clientFactory = new PostmarkClientFactory();
            IPostmarkConfigurationProvider configurationProvider = new PostmarkConfigurationProvider();

            _mailBoxManager = new MailboxManager(mailBoxRepository, clientFactory, configurationProvider);
        }

        public HttpResponseMessage Post([FromBody] OutboundMessageRequest messageRequest)
        {
            // check if valid data is received
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var processResult = _mailBoxManager.ProcessOutboundMessage(messageRequest);

            if (processResult.Status.IsSuccess())
            {
                return Request.CreateResponse(HttpStatusCode.OK, processResult.Message);
            }

            var httpError = new HttpError(processResult.Message);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
        }
    }
}
