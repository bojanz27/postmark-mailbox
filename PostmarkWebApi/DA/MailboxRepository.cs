using System;
using System.Collections.Generic;
using PostmarkWebApi.DA.DTOs;
using PostmarkWebApi.DA.Exceptions;

namespace PostmarkWebApi.DA
{
    internal interface IMailboxRepository
    {
        void InsertMessage(MessageDto messageDto);
        IList<MessageDto> GetAllMessages();
    }

    internal class MailboxRepository : IMailboxRepository
    {
        private readonly MailboxDb _db = new MailboxDb();

        public void InsertMessage(MessageDto messageDto)
        {
            try
            {
                var newMessage = new Message
                {
                    SendFrom = messageDto.SendFrom,
                    SendTo = messageDto.SendTo,
                    Subject = messageDto.Subject,
                    TextBody = messageDto.TextBody,
                    UserGuid = messageDto.UserGuid,
                    DateCreated = messageDto.DateCreated ?? DateTime.Now,
                    DateUpdated = messageDto.DateCreated ?? DateTime.Now,
                    Status = messageDto.Status,
                    ErrorCode = messageDto.ErrorCode
                };

                _db.Add(newMessage);
            }
            catch (Exception e)
            {
                throw new RepositoryException("Exception occured on InsertMessage.", e);
            }
        }

        public IList<MessageDto> GetAllMessages()
        {
            throw new NotImplementedException();
        }
    }
}