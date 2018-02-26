using System;
using System.ComponentModel.DataAnnotations;

namespace PostmarkWebApi.Models
{
    public class OutboundMessageRequest
    {
        [Required]
        public Guid UserGuid { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(256)]
        public string SendTo { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(256)]
        public string SendFrom { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(128)]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string TextBody { get; set; }
    }
}