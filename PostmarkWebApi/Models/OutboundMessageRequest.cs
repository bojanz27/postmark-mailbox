namespace PostmarkWebApi.Models
{
    public class SendMessageRequest
    {
        public string UserGuid { get; set; }
        public string SendTo { get; set; }
        public string SendFrom { get; set; }
        public string Subject { get; set; }
        public string TextBody { get; set; }
    }
}