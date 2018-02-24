using System;

namespace PostmarkWebApi.Models
{
    internal class SendMessagePostmarkResponse
    {
        public int ErrorCode { get; set; }
        public string Status { get; set; }
        public DateTime? SubmittedAt { get; set; }
    }
}