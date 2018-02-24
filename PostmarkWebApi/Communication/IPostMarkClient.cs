using PostmarkWebApi.Models;

namespace PostmarkWebApi.Communication
{
    internal interface IPostmarkClient
    {
        SendMessagePostmarkResponse SendPostmarkMessage(SendMessageRequest newMessageModel);
    }
}