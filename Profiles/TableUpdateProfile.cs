using smartapi.Dtos;
using smartapi.Models;
using AutoMapper;

namespace smartapi.Profiles
{
    public class TableUpdateProfile:Profile
    {
        public TableUpdateProfile()
        {
            CreateMap<TableUpdate,TableUpdateReadDto>();
        }
        
    }    

}