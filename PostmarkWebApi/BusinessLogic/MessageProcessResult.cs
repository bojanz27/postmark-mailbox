namespace PostmarkWebApi.BusinessLogic
{
    internal enum ProcessingStatus
    {
        Success,
        Error
    }

    internal class MessageProcessResult
    {
        public ProcessingStatus Status { get; set; }
        public string Message { get; set; }
    }
}