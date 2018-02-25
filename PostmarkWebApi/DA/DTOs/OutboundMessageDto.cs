using System;

namespace PostmarkWebApi.DA.DTOs
{
    public class OutboundMessageDto
    {   
        public string SendFrom { get; set; }
        
        public string SendTo { get; set; }
        
        public string Subject { get; set; }
        
        public string TextBody { get; set; }

        public Guid UserGuid { get; set; }

        public byte StatusId { get; set; }

        public Guid PostmarkMessageId { get; set; }

        public int? PostmarkErrorCode { get; set; }

        public string PostmarkStatus { get; set; }

        public string PostmarkDescription { get; set; }

        public DateTime? SubmittedAt { get; set; }

        public DateTime? DeliveredAt { get; set; }

        public DateTime? BouncedAt { get; set; }
    }
}