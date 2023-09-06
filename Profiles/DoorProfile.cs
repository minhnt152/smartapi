using smartapi.Dtos;
using smartapi.Models;
using AutoMapper;

namespace smartapi.Profiles
{
    public class DoorProfile:Profile
    {
        public DoorProfile()
        {
            CreateMap<Door,DoorReadDto>();
            CreateMap<DoorUpdateDto,Door>();
            CreateMap<DoorInsertDto,Door>();        
        }
        
    }    

}