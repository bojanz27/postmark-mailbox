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
            CreateMap<OutboundMessageRequest, OutboundMessageDto>();
            CreateMap<OutboundMessageRequest, PostmarkMessage>()
                .ForMember(pm => pm.From, o => o.MapFrom(s => s.SendFrom))
                .ForMember(pm => pm.To, o => o.MapFrom(s => s.SendTo))
                .ForMember(pm => pm.Subject, o => o.MapFrom(s => s.Subject))
                .ForMember(pm => pm.TextBody, o => o.MapFrom(s => s.TextBody));
            CreateMap<PostmarkResponse, OutboundMessagePostmarkResponse>();
            CreateMap<DeliveryRequest, DeliveryUpdateDto>()
                .ForMember(m => m.PostmarkMessageId, o => o.MapFrom(s => s.MessageId));
            CreateMap<BounceRequest, BounceUpdateDto>()
                .ForMember(m => m.PostmarkMessageId, o => o.MapFrom(s => s.MessageId));
        }
    }
}