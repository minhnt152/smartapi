using smartapi.Dtos;
using smartapi.Models;
using AutoMapper;

namespace smartapi.Profiles
{
    public class FacilityProfile:Profile
    {
        public FacilityProfile()
        {
            CreateMap<Facility,FacilityReadDto>();
            CreateMap<FacilityInsertDto,Facility>();
            CreateMap<FacilityUpdateDto,Facility>();        
        }
        
    }    

}