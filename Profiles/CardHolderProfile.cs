using smartapi.Dtos;
using smartapi.Models;
using AutoMapper;

namespace smartapi.Profiles
{
    public class CardHolderProfile:Profile
    {
        public CardHolderProfile()
        {
            CreateMap<CardHolder,CardHolderReadDto>()
                .ForMember(att => att.AccessRights, act => act.MapFrom(src => src.AccessRightHolders.Select(x => x.Right).ToList()));

            CreateMap<CardHolderInsertDto,CardHolder>();
            CreateMap<CardHolderUpdateDto,CardHolder>();
        }
        
    }    

}