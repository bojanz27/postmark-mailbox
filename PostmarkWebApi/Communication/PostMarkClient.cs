using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PostmarkDotNet;
using PostmarkWebApi.Communication.Exceptions;
using PostmarkWebApi.Models;

namespace PostmarkWebApi.Communication
{
    internal class PostmarkClient : IPostmarkClient
    {
        private readonly string _serverToken;

        public PostmarkClient(string serverToken)
        {
            _serverToken = serverToken;
        }

        public OutboundMessagePostmarkResponse SendPostmarkMessage(OutboundMessageRequest messageRequest)
        {
            if (messageRequest == null)
            {
                throw new ArgumentNullException(nameof(messageRequest));
            }

            var postmarkMessage = Mapper.Map<OutboundMessageRequest, PostmarkMessage>(messageRequest);

            var postmarkClient = new PostmarkDotNet.PostmarkClient(_serverToken);

            var postmarkResponse = new PostmarkResponse();

            var task = Task.Run(async () =>
            {
                postmarkResponse = await postmarkClient.SendMessageAsync(postmarkMessage);
            });

            try
            {
                task.Wait();
            }
            catch (AggregateException ae)
            {
                var innerException = ae.InnerExceptions.FirstOrDefault();
                throw new CommunicationException("External service exception occured on SendPostmarkMessage.",
                    innerException);
            }

            return Mapper.Map<PostmarkResponse, OutboundMessagePostmarkResponse>(postmarkResponse);
        }
    }
}