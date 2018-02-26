using PostmarkWebApi.Configuration;

namespace PostmarkWebApi.Communication
{
    internal interface IPostmarkClientFactory
    {
        IPostmarkClient GetClient(IPostmarkConfigurationProvider configurationProvider);
    }
}