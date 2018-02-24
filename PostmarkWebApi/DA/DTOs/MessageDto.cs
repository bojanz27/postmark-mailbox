using System;

namespace PostmarkWebApi.DA.DTOs
{
    public class MessageDto
    {
        public Guid UserGuid { get; set; }
        public string SendTo { get; set; }
        public string SendFrom { get; set; }
        public string Subject { get; set; }
        public int? ErrorCode { get; set; }
        public string TextBody { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}