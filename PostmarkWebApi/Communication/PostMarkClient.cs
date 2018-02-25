using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

        public SendMessagePostmarkResponse SendPostmarkMessage(SendMessageRequest messageRequest)
        {
            if (messageRequest == null)
            {
                throw new ArgumentNullException(nameof(messageRequest));
            }
            
            var postmarkMessage = Mapper.Map<SendMessageRequest, PostmarkMessage>(messageRequest);
 
            var postmarkClient = new PostmarkDotNet.PostmarkClient(_serverToken);

            var postmarkResponse = new PostmarkResponse();

            var task = Task.Run(async () =>
            {
                postmarkResponse = await postmarkClient.SendMessageAsync(postmarkMessage);

                Trace.WriteLine(postmarkResponse.Message); //todo: remove
            });

            try
            {
                task.Wait();
            }
            catch (AggregateException ae)
            {
                var innerException = ae.InnerExceptions.FirstOrDefault();
                throw new CommunicationException("External service exception occured on SendPostmarkMessage.", innerException);
            }
            
            return Mapper.Map<PostmarkResponse, SendMessagePostmarkResponse>(postmarkResponse);
        }
    }
}