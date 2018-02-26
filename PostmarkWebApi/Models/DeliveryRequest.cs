using System;
using System.ComponentModel.DataAnnotations;

namespace PostmarkWebApi.Models
{
    public class DeliveryRequest
    {
        [Required]
        public Guid MessageId { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public string Details { get; set; }
    }
}