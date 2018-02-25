using System;
using System.Linq;
using PostmarkWebApi.DA.DTOs;
using PostmarkWebApi.DA.Exceptions;

namespace PostmarkWebApi.DA
{
    internal interface IMailboxRepository
    {
        void InsertOutboundMessage(OutboundMessageDto messageDto);
        void UpdateStatusDelivered(DeliveryUpdateDto deliveryDto);
        void UpdateStatusBounced(BounceUpdateDto bouncedDto);
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

        public void UpdateStatusDelivered(DeliveryUpdateDto deliveryDto)
        {
            try
            {
                // get the message by messageId guid 
                var message = GetByPostmarkMessageGuid(deliveryDto.PostmarkMessageId);

                // this case should never happen - if it does we must raise an exception
                if (message == null)
                {
                    throw new RepositoryException(
                        $"Message with PostmarkMessageId = {deliveryDto.PostmarkMessageId} not found. ", null);
                }

                // update message data
                message.StatusId = (byte) OutboundMessageStatus.Delivered;
                message.DeliveredAt = deliveryDto.DeliveredAt;
                message.PostmarkStatus = deliveryDto.Details;

                _db.Update(message);
            }
            catch (Exception e)
            {
                throw new RepositoryException("Internal exception occured on UpdateStatusDelivered.", e);
            }
        }

        public void UpdateStatusBounced(BounceUpdateDto bouncedDto)
        {
            try
            {
                // get the message by messageId guid 
                var message = GetByPostmarkMessageGuid(bouncedDto.PostmarkMessageId);

                // this case should never happen - if it does we must raise an exception
                if (message == null)
                {
                    throw new RepositoryException(
                        $"Message with PostmarkMessageId = {bouncedDto.PostmarkMessageId} not found. ", null);
                }

                // update message data
                message.StatusId = (byte)OutboundMessageStatus.BouncedBack;
                message.BouncedAt = bouncedDto.BouncedAt;
                message.PostmarkStatus = bouncedDto.Details;
                message.PostmarkDescription = bouncedDto.Description;

                _db.Update(message);
            }
            catch (Exception e)
            {
                throw new RepositoryException("Internal exception occured on UpdateStatusBounced.", e);
            }
        }

        #region Private methods

        private OutboundMessage GetByPostmarkMessageGuid(Guid messageGuid)
        {
            using (var ctx = new MailboxContext()) // move to db class
            {
                return ctx.Messages.SingleOrDefault(m => m.PostmarkMessageId == messageGuid);
            }
        }

        #endregion
    }
}