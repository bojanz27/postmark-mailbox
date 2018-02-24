using PostmarkWebApi.Configuration;

namespace PostmarkWebApi.Communication
{
    internal class PostmarkClientFactory : IPostmarkClientFactory
    {
        public IPostmarkClient GetClient(IPostmarkConfigurationProvider configurationProvider)
        {
            return new PostmarkClient(configurationProvider.GetConfiguration().ServerToken);
        }
    }
}