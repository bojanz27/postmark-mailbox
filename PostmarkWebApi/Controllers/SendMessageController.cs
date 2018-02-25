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
 * communication logger
 * backoffice / admin portal
 * AUTHENTICATION
 * 
 * question - plan text or html images? enable html messages maybe
 * 
 * history status tracking
 * 
 * Request validation!!!!!
 * 
 */

namespace PostmarkWebApi.Controllers
{
    public class SendMessageController : ApiController //rename to send message
    {
        private static readonly IEnumerable<MessageModel> Emails = new List<MessageModel>()
        {
            new MessageModel{TextBody= "Hello there!", SendFrom="john@abc.com",SendTo = "jane@abc.com", UserGuid = "12345"},
            new MessageModel{TextBody = "Hello back!", SendFrom = "jane@abc.com", SendTo = "john@abc.com", UserGuid = "54321"}
        };

        private readonly IMailboxManager _mailBoxManager;

        public SendMessageController()
        {
            IMailboxRepository mailBoxRepository = new MailboxRepository();
            IPostmarkClientFactory clientFactory = new PostmarkClientFactory();
            IPostmarkConfigurationProvider configurationProvider = new PostmarkConfigurationProvider();

            _mailBoxManager =new MailboxManager(mailBoxRepository,clientFactory, configurationProvider);
        }

        public IEnumerable<MessageModel> GetAllEmails()
        {
            return Emails;
        }

        public HttpResponseMessage Post([FromBody] SendMessageRequest messageRequest) //test exception
        {
            var result = _mailBoxManager.ProcessSendMessage(messageRequest);

            if (result.Status.IsSucess())
            {
                return Request.CreateResponse(HttpStatusCode.OK, result.Message);
            }

            var httpError = new HttpError(result.Message);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
        }
    }
}
