using smartapi.Dtos;
using smartapi.Models;
using AutoMapper;

namespace smartapi.Profiles
{
    public class PeriodProfile:Profile
    {
        public PeriodProfile()
        {
            CreateMap<Period,PeriodDto>();
            CreateMap<PeriodInsertDto,Period>();        
        }        
    }    

}