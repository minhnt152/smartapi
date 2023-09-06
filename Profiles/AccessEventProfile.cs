using smartapi.Dtos;
using smartapi.Models;
using AutoMapper;

namespace smartapi.Profiles
{
    public class AccessEventProfile:Profile
    {
        public AccessEventProfile()
        {
            CreateMap<AccessEvent,AccessEventReadDto>();
            CreateMap<AccessEventInsertDto,AccessEvent>();
        }
        
    }    

}