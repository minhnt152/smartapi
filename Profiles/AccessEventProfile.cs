using smartapi.Dtos;
using smartapi.Models;
using AutoMapper;

namespace smartapi.Profiles
{
    public class AccessEventProfile:Profile
    {
        public AccessEventProfile()
        {
            CreateMap<AccessEvent,AccessEventReadDto>()
            .ForMember(att => att.EventCode, act => act.MapFrom(src => src.EventStt))
            .ForMember(att => att.Direction, act => act.MapFrom(src => src.Orientation));
;

            CreateMap<AccessEventInsertDto,AccessEvent>()
            .ForMember(att => att.EventStt, act => act.MapFrom(src => src.EventCode))
            .ForMember(att => att.Orientation, act => act.MapFrom(src => src.Direction));
        }
        
    }    

}