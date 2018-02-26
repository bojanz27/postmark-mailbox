using System;
using System.ComponentModel.DataAnnotations;

namespace PostmarkWebApi.Models
{
    public class BounceRequest
    {
        [Required]
        public Guid MessageId { get; set; }
        public DateTime? BouncedAt { get; set; }
        public string Details { get; set; }
        public string Description { get; set; }
    }
}