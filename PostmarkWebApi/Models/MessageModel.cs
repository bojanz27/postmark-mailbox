using System;

namespace PostmarkWebApi.Models
{
    public class MessageModel
    {
        public string UserGuid { get; set; }
        public string SendTo { get; set; }
        public string SendFrom { get; set; }
        public string Subject { get; set; }
        public string TextBody { get; set; }
        public string Status { get; set; }

        //error code
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}