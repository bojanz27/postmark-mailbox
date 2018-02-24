using AutoMapper;
using PostmarkDotNet;
using PostmarkWebApi.DA.DTOs;
using PostmarkWebApi.Models;

namespace PostmarkWebApi.Mappers.AutoMapper
{
    public class MailboxProfile : Profile
    {
        public override string ProfileName => "MailboxProfile";

        public MailboxProfile()
        {
            CreateMap<SendMessageRequest, MessageDto>();
            CreateMap<MessageModel, MessageDto>();
            CreateMap<SendMessageRequest, PostmarkMessage>()
                .ForMember(pm => pm.From, o => o.MapFrom(s => s.SendFrom))
                .ForMember(pm => pm.To, o => o.MapFrom(s => s.SendTo))
                .ForMember(pm => pm.Subject, o => o.MapFrom(s => s.Subject))
                .ForMember(pm => pm.TextBody, o => o.MapFrom(s => s.TextBody));
            CreateMap<PostmarkResponse, SendMessagePostmarkResponse>();
        }
    }
}