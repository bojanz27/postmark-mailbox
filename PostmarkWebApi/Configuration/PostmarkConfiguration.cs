using System.Configuration;

namespace PostmarkWebApi.Configuration
{
    public class PostmarkConfiguration : ConfigurationSection, IPostmarkConfiguration
    {
        [ConfigurationProperty("serverToken", IsRequired = true)]
        public string ServerToken
        {
            get => (string) this["serverToken"];
            set => this["serverToken"] = value;
        }
    }
}