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
    public class BounceController : ApiController
    {
        private readonly IMailboxManager _mailBoxManager;

        public BounceController()
        {
            IMailboxRepository mailBoxRepository = new MailboxRepository();
            IPostmarkClientFactory clientFactory = new PostmarkClientFactory();
            IPostmarkConfigurationProvider configurationProvider = new PostmarkConfigurationProvider();

            _mailBoxManager = new MailboxManager(mailBoxRepository, clientFactory, configurationProvider);
        }

        public HttpResponseMessage Post([FromBody] BounceRequest bounceRequest)
        {
            var result = _mailBoxManager.ProcessBouncedStatusUpdate(bounceRequest);

            return Request.CreateResponse(
                result.Status.IsSuccess()
                    ? HttpStatusCode.OK
                    : HttpStatusCode.InternalServerError);
        }
    }
}
