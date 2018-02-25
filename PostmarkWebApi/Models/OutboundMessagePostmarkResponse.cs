using System;

namespace PostmarkWebApi.Models
{
    internal class OutboundMessagePostmarkResponse
    {
        public Guid MessageId { get; set; }
        public int? ErrorCode { get; set; }
        public string Status { get; set; }
        public DateTime? SubmittedAt { get; set; }
    }
}