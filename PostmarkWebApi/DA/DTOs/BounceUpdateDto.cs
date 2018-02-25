using System;

namespace PostmarkWebApi.DA.DTOs
{
    public class BounceUpdateDto
    {
        public Guid PostmarkMessageId { get; set; }
        public DateTime? BouncedAt { get; set; }
        public string Details { get; set; }
        public string Description { get; set; }
    }
}