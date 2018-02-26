namespace PostmarkWebApi.Configuration
{
    internal interface IPostmarkConfigurationProvider
    {
        IPostmarkConfiguration GetConfiguration();
    }
}