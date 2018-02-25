using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostmarkWebApi.Models
{
    public class DeliveryRequest
    {
        public Guid MessageId { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public string Details { get; set; }
    }
}