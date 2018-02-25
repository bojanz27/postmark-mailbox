using System;
using System.Collections.Generic;
using System.Linq;
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
    public class DeliveryController : ApiController
    {
        private readonly IMailboxManager _mailBoxManager;

        public DeliveryController()
        {
            IMailboxRepository mailBoxRepository = new MailboxRepository();
            IPostmarkClientFactory clientFactory = new PostmarkClientFactory();
            IPostmarkConfigurationProvider configurationProvider = new PostmarkConfigurationProvider();

            _mailBoxManager = new MailboxManager(mailBoxRepository, clientFactory, configurationProvider);
        }

        public HttpResponseMessage Post([FromBody] DeliveryRequest messageRequest)
        {
            var result = _mailBoxManager.ProcessDeliveredStatusUpdate(messageRequest);

            return Request.CreateResponse(
                result.Status.IsSuccess()
                    ? HttpStatusCode.OK
                    : HttpStatusCode.InternalServerError);
        }
    }
}
