using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PostmarkWebApi.BusinessLogic;
using PostmarkWebApi.Communication;
using PostmarkWebApi.Configuration;
using PostmarkWebApi.DA;
using PostmarkWebApi.Helpers;
using PostmarkWebApi.Models;

/*
 * file LOGGER - 
 * communication logger - if for example postmark is down we should see failing emails 
 * also log fialed emails
 * backoffice / admin portal
 * AUTHENTICATION
 * 
 * question - plan text or html images? enable html messages maybe
 * 
 * history status tracking
 * 
 * Request validation!!!!!
 * 
 * throw http exc form webapi or just wrap error/status in 200 ok response
 * 
 * store massages not sent to postmark? ex when postmark returns errorcode <> ok
 * 
 */

namespace PostmarkWebApi.Controllers
{
    public class SendMessageController : ApiController
    {

        private readonly IMailboxManager _mailBoxManager;

        public SendMessageController()
        {
            IMailboxRepository mailBoxRepository = new MailboxRepository();
            IPostmarkClientFactory clientFactory = new PostmarkClientFactory();
            IPostmarkConfigurationProvider configurationProvider = new PostmarkConfigurationProvider();

            _mailBoxManager =new MailboxManager(mailBoxRepository,clientFactory, configurationProvider);
        }


        public HttpResponseMessage Post([FromBody] SendMessageRequest messageRequest)
        {
            var result = _mailBoxManager.ProcessSendMessage(messageRequest);

            if (result.Status.IsSuccess())
            {
                return Request.CreateResponse(HttpStatusCode.OK, result.Message);
            }

            var httpError = new HttpError(result.Message);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
        }
    }
}
