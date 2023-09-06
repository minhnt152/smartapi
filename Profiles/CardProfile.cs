using smartapi.Dtos;
using smartapi.Models;
using AutoMapper;

namespace smartapi.Profiles
{
    public class CardProfile:Profile
    {
        public CardProfile()
        {
            CreateMap<Card,CardReadDto>();
            CreateMap<CardInsertDto,Card>();
            CreateMap<CardUpdateDto,Card>();     

            CreateMap<CitizenIdCard,CitizenIDCardReadDto>();
            CreateMap<CitizenIDCardInsertDto,CitizenIdCard>();        
        }
        
    }    

}