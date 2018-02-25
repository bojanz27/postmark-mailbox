using System;

namespace PostmarkWebApi.DA.DTOs
{
    internal class DeliveryUpdateDto
    {
        public Guid PostmarkMessageId { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public string Details { get; set; }
    }
}