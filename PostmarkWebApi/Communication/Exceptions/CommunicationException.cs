using System;

namespace PostmarkWebApi.Communication.Exceptions
{
    public class CommunicationException : Exception
    {
        public CommunicationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}