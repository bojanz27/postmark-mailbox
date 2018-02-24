using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostmarkWebApi.DA
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(254)]
        public string SendFrom { get; set; }

        [Required]
        [StringLength(254)]
        public string SendTo { get; set; }

        [Required]
        [StringLength(254)]
        public string Subject { get; set; }

        [Required]
        public string TextBody { get; set; }

        public Guid UserGuid { get; set; }

        public string Status { get; set; }

        public int? ErrorCode { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
