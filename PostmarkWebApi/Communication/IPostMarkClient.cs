using PostmarkWebApi.Models;

namespace PostmarkWebApi.Communication
{
    internal interface IPostmarkClient
    {
        OutboundMessagePostmarkResponse SendPostmarkMessage(OutboundMessageRequest newMessageModel);
    }
}