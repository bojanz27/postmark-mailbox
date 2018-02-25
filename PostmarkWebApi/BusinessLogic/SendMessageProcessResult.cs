using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostmarkWebApi.BusinessLogic
{
    internal enum ProcessingStatus
    {
        Success,
        Fail
    }

    internal class MessageProcessResult
    {
        public ProcessingStatus Status { get; set; }
        public string Message { get; set; }
    }
}