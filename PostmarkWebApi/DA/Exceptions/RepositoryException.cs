using System;

namespace PostmarkWebApi.DA.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}