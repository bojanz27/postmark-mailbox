using AutoMapper;

namespace PostmarkWebApi.Mappers.AutoMapper
{
    public class Configuration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<MailboxProfile>(); });
        }
    }
}