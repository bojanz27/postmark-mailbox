﻿using System;

namespace PostmarkWebApi.Models
{
    public class BounceRequest
    {
        public Guid MessageId { get; set; }
        public DateTime? BouncedAt { get; set; }
        public string Details { get; set; }
        public string Description { get; set; }
    }
}