using System;
using PostmarkWebApi.DA.DTOs;
using PostmarkWebApi.DA.Exceptions;

namespace PostmarkWebApi.DA
{
    internal interface IMailboxRepository
    {
        void InsertOutboundMessage(OutboundMessageDto messageDto);
    }

    internal class MailboxRepository : IMailboxRepository
    {
        private readonly MailboxDb _db = new MailboxDb();

        public void InsertOutboundMessage(OutboundMessageDto messageDto)
        {
            try
            {
                var newMessage = new OutboundMessage
                {
                    SendFrom = messageDto.SendFrom,
                    SendTo = messageDto.SendTo,
                    Subject = messageDto.Subject,
                    TextBody = messageDto.TextBody,
                    UserGuid = messageDto.UserGuid,
                    StatusId = messageDto.StatusId,
                    PostmarkMessageId = messageDto.PostmarkMessageId,
                    PostmarkErrorCode = messageDto.PostmarkErrorCode,
                    PostmarkStatus = messageDto.PostmarkStatus,
                    SubmittedAt = messageDto.SubmittedAt ?? DateTime.Now
                };

                _db.Add(newMessage);
            }
            catch (Exception e)
            {
                throw new RepositoryException("Internal exception occured on InsertOutboundMessage.", e);
            }
        }
    }
}