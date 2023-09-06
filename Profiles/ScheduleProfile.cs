using smartapi.Dtos;
using smartapi.Models;
using AutoMapper;

namespace smartapi.Profiles
{
    public class ScheduleProfile:Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule,ScheduleReadDto>();
            CreateMap<ScheduleInsertDto,Schedule>();
            CreateMap<ScheduleUpdateDto,Schedule>();
        }
        
    }    

}