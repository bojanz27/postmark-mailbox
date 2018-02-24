using System;
using AutoMapper;
using PostmarkWebApi.Communication;
using PostmarkWebApi.Configuration;
using PostmarkWebApi.DA;
using PostmarkWebApi.DA.DTOs;
using PostmarkWebApi.Models;

namespace PostmarkWebApi.BusinessLogic
{
    internal interface IMailboxManager
    {
        SendMessageProcessResult ProcessSendMessage(SendMessageRequest pendingEmail);
    }
    
    internal class MailboxManager : IMailboxManager
    {
        private readonly IMailboxRepository _mailBoxRepository;
        private readonly IPostmarkClientFactory _clientFactory;
        private readonly IPostmarkConfigurationProvider _configurationProvider;
         
        public MailboxManager(IMailboxRepository mailBoxRepository, IPostmarkClientFactory clientFactory, IPostmarkConfigurationProvider configurationProvider)
        {
            _mailBoxRepository = mailBoxRepository;
            _clientFactory = clientFactory;
            _configurationProvider = configurationProvider;
        }
        
        public SendMessageProcessResult ProcessSendMessage(SendMessageRequest messageRequest)
        {
            var result = new SendMessageProcessResult();
            try
            {
                // send to postmark
                var postmarkClient = _clientFactory.GetClient(_configurationProvider);
                var response = postmarkClient.SendPostmarkMessage(messageRequest);

                // insert to database
                var newMessage = Mapper.Map<SendMessageRequest, MessageDto>(messageRequest);
                newMessage.ErrorCode = response.ErrorCode;
                newMessage.DateCreated = response.SubmittedAt;
                newMessage.Status = response.Status;

                _mailBoxRepository.InsertMessage(newMessage);
                
                // client should return response - update email in database 
                result.Status = ProcessingStatus.Success;
                result.Message = response.Status;
            }
            catch (Exception e)
            {
                result.Status = ProcessingStatus.Fail;
                result.Message = $"{e.Message} {e.InnerException?.Message}";
            }

            return result;
        }
    }
}