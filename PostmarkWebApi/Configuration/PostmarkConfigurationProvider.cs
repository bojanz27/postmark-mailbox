using System.Configuration;

namespace PostmarkWebApi.Configuration
{
    internal class PostmarkConfigurationProvider : IPostmarkConfigurationProvider
    {
        private IPostmarkConfiguration _configuration;
        public IPostmarkConfiguration GetConfiguration()
        {
            return _configuration ??
                   (_configuration = ConfigurationManager.GetSection("postmark") as IPostmarkConfiguration);
        }
    }
}