using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostmarkWebApi.DA
{
    [Table("OutboundMessage")]
    public class OutboundMessage
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(256)]
        public string SendFrom { get; set; }

        [Required]
        [StringLength(256)]
        public string SendTo { get; set; }

        [Required]
        [StringLength(128)]
        public string Subject { get; set; }

        [Required]
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
